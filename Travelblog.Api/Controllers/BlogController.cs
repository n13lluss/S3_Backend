using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travelblog.Api.Models.BlogDto;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly ICountryService _countryService;
        private readonly IHubContext<BlogHub> _hubContext;

            public BlogController(IConfiguration configuration, IBlogService blogService, IUserService userService, ICountryService countryService, IHubContext<BlogHub> hubContext)
        {
            _blogService = blogService;
            _userService = userService;
            _configuration = configuration;
            _countryService = countryService;
            _hubContext = hubContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string? IdString)
        {
            List<BlogSlimDTO> smallBlogs = (await _blogService.GetBlogList())
                .Where(blog => !blog.IsDeleted)
                .Select(blog => new BlogSlimDTO
                {
                    Id = blog.Id,
                    User_Name = _userService.GetById(blog.User_Id).UserName,
                    Name = blog.Name,
                    Description = blog.Description,
                    Posted_On = blog.StartDate,
                    Countries = blog.Countries,
                    likes = blog.Likes,
                    liked = IdString != null ? _blogService.Liked(blog, _userService.GetUserById(IdString)) : false,
                })
                .ToList();

            return Ok(smallBlogs);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id, string? IdString)
        {
            Blog blog = await _blogService.GetBlogById(id);

            if (blog == null)
            {
                return NotFound();
            }

            bool liked = false;
            if (IdString != null)
            {
                liked = _blogService.Liked(blog, _userService.GetUserById(IdString));
            }

            BlogViewDto blogViewDto = new()
            {
                Id = blog.Id,
                User_Name = _userService.GetNameById(blog.User_Id),
                Name = blog.Name,
                Creator_Id = _userService.GetById(blog.User_Id).IdString,
                Description = blog.Description,
                StartDate = blog.StartDate,
                Likes = blog.Likes,
                Liked = liked,
                Posts = blog.Posts,
                Followers = blog.Followers.Count,
                IsDeleted = blog.IsDeleted,
                IsPrive = blog.IsPrive,
                IsSuspended = blog.IsSuspended,
                Countries = blog.Countries,
            };

            return Ok(blogViewDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BlogCreationDto createdBlog)
        {
            if (createdBlog == null)
            {
                return BadRequest("Invalid input");
            }

            // Adding default user information
            User defaultUser = new();
            _configuration.GetSection("DefaultUser").Bind(defaultUser);
            //

            Blog newBlog = new()
            {
                User_Id = _userService.GetUserByName(createdBlog.Username).Id,
                Name = createdBlog.Name,
                Description = createdBlog.Description,
                StartDate = DateTime.UtcNow
            };

            Blog created = await _blogService.CreateBlog(newBlog);

            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBlogDto updatedBlog)
        {
            Blog found = await _blogService.GetBlogById(id);

            if (found == null)
            {
                return NotFound();
            }

            if (updatedBlog == null)
            {
                return BadRequest("Invalid input");
            }

            var countries = new List<Country>();

            foreach (var country in updatedBlog.Countries)
            {
                countries.Add(await _countryService.GetCountryById(country));
            }

            found.Name = updatedBlog.Name;
            found.Description = updatedBlog.Description;
            found.IsSuspended = updatedBlog.IsSuspended;
            found.IsDeleted = updatedBlog.IsDeleted;
            found.IsPrive = updatedBlog.IsPrive;
            found.Trip_Id = updatedBlog.Trip_Id;
            found.Countries = countries;

            await _blogService.UpdateBlog(found);

            return NoContent();
        }

        [HttpPost("{id}/like")]
        public async Task<IActionResult> Like(int id, [FromBody] string username)
        {
            Blog found = await _blogService.GetBlogById(id);

            if (found == null)
            {
                return NotFound();
            }
            _blogService.LikeBlog(found, _userService.GetUserById(username));

            await _hubContext.Clients.All.SendAsync("ReceiveBlogUpdate", "A blog has been liked.");

            return NoContent();
        }


        [HttpPost("{id}/follow")]
        public async Task<IActionResult> Follow(int id, [FromBody] string IdString)
        {
            Blog found = await _blogService.GetBlogById(id);

            if (found == null)
            {
                return NotFound();
            }

            _blogService.AddFollower(found, _userService.GetUserById(IdString));
            return NoContent();
        }

        [HttpPost("{Id}/country")]
        [AllowAnonymous]
        public async Task<IActionResult> AddCountry(int Id, [FromBody] List<Country> countries)
        {
            Blog found = await _blogService.GetBlogById(Id);

            if (found == null)
            {
                return NotFound();
            }

            Blog blog = await _blogService.AddCountries(found, countries);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Blog existingBlog = await _blogService.GetBlogById(id);

            if (existingBlog == null)
            {
                return NotFound();
            }

            existingBlog.IsDeleted = !existingBlog.IsDeleted;

            await _blogService.UpdateBlog(existingBlog);
            return NoContent();
        }
    }
}
