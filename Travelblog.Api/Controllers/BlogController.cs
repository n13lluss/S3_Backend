using Microsoft.AspNetCore.Mvc;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Travelblog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly List<Blog> blogs1 = new List<Blog>();
        private IBlogService _blogService;
        public BlogController(IBlogService blogservice) {
            _blogService = blogservice;
        }

        // GET: api/<BlogController>
        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Blog> Get()
        {
            List<Blog> blogs = _blogService.GetBlogList();
            return blogs.ToArray();
        }

        // GET api/<BlogController>/5
        [HttpGet("getById={id}")]
        public Blog Get(int id)
        {
            return blogs1[id];
        }

        // POST api/<BlogController>
        [HttpPost("create")]
        public IActionResult Create([FromBody] Blog newBlog)
        {
            if (newBlog == null)
            {
                return BadRequest("Invalid input");
            }
            newBlog.Id = blogs1.Count;
            newBlog.StartDate = DateTime.UtcNow;
            blogs1.Add(newBlog);
            return CreatedAtAction(nameof(Get), new { id = newBlog.Id }, newBlog);
        }

        // PUT api/<BlogController>/5
        [HttpPut("update={id}")]
        public IActionResult Put(int id, [FromBody] Blog updatedBlog)
        {
            if (id < 0 || id >= blogs1.Count)
            {
                return NotFound();
            }
            if (updatedBlog == null)
            {
                return BadRequest("Invalid input");
            }
            blogs1[id] = updatedBlog;
            return NoContent();
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("delete={id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= blogs1.Count)
            {
                return NotFound();
            }
            blogs1.RemoveAt(id);
            return NoContent();
        }
    }
}
