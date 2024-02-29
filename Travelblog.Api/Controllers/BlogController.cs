using Microsoft.AspNetCore.Mvc;
using Travelblog.Api.Models;
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
            List<BlogSlimDTO> smallBlogs = _blogService.GetBlogList().Select(blog =>
            {
                return new BlogSlimDTO
                {
                    Id = blog.Id,
                    User_Name = _userService.GetNameById(blog.User_Id), 
                    Name = blog.Name,
                    Posted_On = blog.StartDate,
                };
            }).ToList();

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
        public IActionResult Create([FromBody] Blog newBlog)
        {
            if (newBlog == null)
            {
                return BadRequest("Invalid input");
            }

            Blog createdBlog = _blogService.CreateBlog(newBlog);
            return CreatedAtAction(nameof(Get), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("update={id}")]
        public IActionResult Put(int id, [FromBody] Blog updatedBlog)
        {
            if (id < 1000)
            {
                return NotFound();
            }

            if (updatedBlog == null)
            {
                return BadRequest("Invalid input");
            }

            _blogService.UpdateBlog(updatedBlog);
            return NoContent();
        }

        [HttpDelete("delete={id}")]
        public IActionResult Delete(int id)
        {
            if (id < 1000)
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
