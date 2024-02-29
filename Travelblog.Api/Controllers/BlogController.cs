using Microsoft.AspNetCore.Mvc;
using Travelblog.Api.Models.BlogDto;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Travelblog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlogService _blogService;
        private IUserService _userService;
        public BlogController(IBlogService blogservice, IUserService userService) {
            _blogService = blogservice;
            _userService = userService;
        }

        [HttpGet("getAll")]
        public IActionResult Get()
        {
            List<BlogSlimDTO> smallBlogs = _blogService.GetBlogList()
                .Where(blog => !blog.IsDeleted) // Filter out deleted blogs
                .Select(blog => new BlogSlimDTO
                {
                    Id = blog.Id,
                    User_Name = _userService.GetNameById(blog.User_Id),
                    Name = blog.Name,
                    Posted_On = blog.StartDate,
                })
                .ToList();

            return Ok(smallBlogs);
        }


        [HttpGet("getById={id}")]
        public IActionResult Get(int id)
        {
            Blog blog = _blogService.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] BlogCreationDto CreatedBlog)
        {
            if (CreatedBlog == null)
            {
                return BadRequest("Invalid input");
            }

            Blog newBlog = new()
            {
                User_Id = CreatedBlog.UserId,
                Name = CreatedBlog.Name,
                StartDate = CreatedBlog.CreationTime
            };

            Blog createdBlog = _blogService.CreateBlog(newBlog);
            return CreatedAtAction(nameof(Get), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("update={id}")]
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

        [HttpDelete("delete={id}")]
        public IActionResult Delete(int id)
        {
            if (_blogService.GetBlogById(id) == null)
            {
                return NotFound();
            }

            Blog DeletedBlog = _blogService.GetBlogById(id);
            DeletedBlog.IsDeleted = true;
            _blogService.UpdateBlog(DeletedBlog);
            return NoContent();
        }
    }
}
