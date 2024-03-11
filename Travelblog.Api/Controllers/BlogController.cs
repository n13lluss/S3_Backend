﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travelblog.Api.Models.BlogDto;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Travelblog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogController : ControllerBase
    {
        private IBlogService _blogService;
        private IUserService _userService;
        private IConfiguration _configuration;
        public BlogController(IConfiguration configuration, IBlogService blogservice, IUserService userService) {
            _blogService = blogservice;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            List<BlogSlimDTO> smallBlogs = _blogService.GetBlogList()
                .Where(blog => !blog.IsDeleted)
                .Select(blog => new BlogSlimDTO
                {
                    Id = blog.Id,
                    User_Name = _userService.GetNameById(blog.User_Id),
                    Name = blog.Name,
                    Description = blog.Description,
                    Posted_On = blog.StartDate,
                    likes = blog.Likes,
                })
                .ToList();

            return Ok(smallBlogs);
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            Blog blog = _blogService.GetBlogById(id);
            BlogViewDto blogViewDto = new BlogViewDto()
            {
                Id = blog.Id,
                User_Name = _userService.GetNameById(blog.User_Id),
                Name = blog.Name,
                Description = blog.Description,
                StartDate = blog.StartDate,
                Likes = blog.Likes,
                Posts = blog.Posts,
                Followers = blog.Followers.Count(),
                IsDeleted = blog.IsDeleted,
                IsPrive = blog.IsPrive,
                IsSuspended = blog.IsSuspended,
                Countries = blog.Countries,

            };
            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blogViewDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BlogCreationDto CreatedBlog)
        {
            //Adding default user information 
            User DefaultUser = new User();
            _configuration.GetSection("DefaultUser").Bind(DefaultUser);
            //

            if (CreatedBlog == null)
            {
                return BadRequest("Invalid input");
            }

            Blog newBlog = new()
            {
                User_Id = DefaultUser.Id,
                Name = CreatedBlog.Name,
                Description= CreatedBlog.Description,
                StartDate = DateTime.UtcNow
            };

            Blog createdBlog = _blogService.CreateBlog(newBlog);
            return CreatedAtAction(nameof(Get), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateBlogDto updatedBlog)
        {
            Blog found = _blogService.GetBlogById(id);

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


            _blogService.UpdateBlog(found);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (_blogService.GetBlogById(id) == null)
            {
                return NotFound();
            }

            Blog DeletedBlog = _blogService.GetBlogById(id);
            if (DeletedBlog.IsDeleted)
            {
                DeletedBlog.IsDeleted = false;
            }
            else
            {
                DeletedBlog.IsDeleted = true;
            }
            _blogService.UpdateBlog(DeletedBlog);
            return NoContent();
        }
    }
}
