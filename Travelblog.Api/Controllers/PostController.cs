using Microsoft.AspNetCore.Mvc;
using Travelblog.Api.Models.PostDto;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Travelblog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IBlogService _blogService;
        private IUserService _userService;
        private IConfiguration _configuration;
        private IPostService _postService;
        public PostController(IConfiguration configuration, IBlogService blogservice, IUserService userService, IPostService postService)
        {
            _blogService = blogservice;
            _userService = userService;
            _configuration = configuration;
            _postService = postService;
        }
        // POST api/<PostController>
        [HttpPost]
        public void Post([FromBody] PostCreationDto post)
        {
            int blogId = post.BlogId;

            Post newpost = new()
            {
                Name = post.Name,
                Description = post.Description,
                Posted = DateTime.Now,
            };
            _postService.CreatePost(newpost, blogId);   
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
