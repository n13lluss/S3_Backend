using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
    [Authorize]
    public class BlogController(IConfiguration configuration, IBlogService blogservice, IUserService userService) : ControllerBase
    {
        private readonly IBlogService _blogService = blogservice;
        private readonly IUserService _userService = userService;
        private readonly IConfiguration _configuration = configuration;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string? username)
        {
            List<BlogSlimDTO> smallBlogs = (await _blogService.GetBlogList())
                .Where(blog => !blog.IsDeleted)
                .Select(blog => new BlogSlimDTO
                {
                    Id = blog.Id,
                    User_Name = _userService.GetNameById(blog.User_Id),
                    Name = blog.Name,
                    Description = blog.Description,
                    Posted_On = blog.StartDate,
                    likes = blog.Likes,
                    liked = username != null ? _blogService.Liked(blog, _userService.GetUserByName(username)) : false,
                })
                .ToList();

            return Ok(smallBlogs);
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id, string? username)
        {
            Blog blog = await _blogService.GetBlogById(id);

            if (blog == null)
            {
                return NotFound();
            }

            bool liked = false;
            if (username != null)
            {
                liked = _blogService.Liked(blog, _userService.GetUserByName(username));
            }

            BlogViewDto blogViewDto = new()
            {
                Id = blog.Id,
                User_Name = _userService.GetNameById(blog.User_Id),
                Name = blog.Name,
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
        [Authorize]
        public IActionResult Create([FromBody] BlogCreationDto CreatedBlog)
        {
            if (CreatedBlog == null)
            {
                return BadRequest("Invalid input");
            }

            // Adding default user information
            User DefaultUser = new();
            _configuration.GetSection("DefaultUser").Bind(DefaultUser);
            //

            Blog newBlog = new()
            {
                User_Id = _userService.GetUserByName(CreatedBlog.Username).Id,
                Name = CreatedBlog.Name,
                Description = CreatedBlog.Description,
                StartDate = DateTime.UtcNow
            };

            Blog createdBlog = _blogService.CreateBlog(newBlog);
            return CreatedAtAction(nameof(Get), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        [Authorize]
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

            found.Name = updatedBlog.Name;
            found.Description = updatedBlog.Description;
            found.IsSuspended = updatedBlog.IsSuspended;
            found.IsDeleted = updatedBlog.IsDeleted;
            found.IsPrive = updatedBlog.IsPrive;
            found.Trip_Id = updatedBlog.Trip_Id;

            await _blogService.UpdateBlog(found);
            return NoContent();
        }

        [HttpPut("{id}/like")]
        [AllowAnonymous]
        public async Task<IActionResult> Like(int id, [FromBody] string username)
        {
            Blog found = await _blogService.GetBlogById(id);

            if (found == null)
            {
                return NotFound();
            }
            _blogService.LikeBlog(found, _userService.GetUserByName(username));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            Blog existingBlog = await _blogService.GetBlogById(id);

            if (existingBlog == null)
            {
                return NotFound();
            }

            if (existingBlog.IsDeleted)
            {
                existingBlog.IsDeleted = false;
            }
            else
            {
                existingBlog.IsDeleted = true;
            }

            await _blogService.UpdateBlog(existingBlog);
            return NoContent();
        }
    }
}
