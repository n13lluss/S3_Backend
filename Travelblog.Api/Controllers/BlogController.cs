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
        public List<Blog> blogs = new List<Blog>();
        // GET: api/<BlogController>
        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Blog> Get()
        {
            return blogs.ToArray();
        }

        // GET api/<BlogController>/5
        [HttpGet("getById={id}")]
        public Blog Get(int id)
        {
            return blogs[id];
        }

        // POST api/<BlogController>
        [HttpPost("create")]
        public IActionResult Create([FromBody] Blog newBlog)
        {
            if (newBlog == null)
            {
                return BadRequest("Invalid input");
            }
            newBlog.Id = blogs.Count;
            newBlog.StartDate = DateTime.UtcNow;
            blogs.Add(newBlog);
            return CreatedAtAction(nameof(Get), new { id = newBlog.Id }, newBlog);
        }

        // PUT api/<BlogController>/5
        [HttpPut("update={id}")]
        public IActionResult Put(int id, [FromBody] Blog updatedBlog)
        {
            if (id < 0 || id >= blogs.Count)
            {
                return NotFound();
            }
            if (updatedBlog == null)
            {
                return BadRequest("Invalid input");
            }
            blogs[id] = updatedBlog;
            return NoContent();
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("delete={id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= blogs.Count)
            {
                return NotFound();
            }
            blogs.RemoveAt(id);
            return NoContent();
        }
    }
}
