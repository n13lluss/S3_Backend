using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travelblog.Api.Models.PostDto;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController(IPostService postService) : ControllerBase
    {
        private readonly IPostService _postService = postService;

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
            _postService.CreatePostAsync(newpost, blogId);   
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PostUpdateDto value)
        {
            if (id <= 0 || value == null)
            {
                return BadRequest("Invalid input");
            }

            Post existingPost = await _postService.GetPostByIdAsync(id);

            if (existingPost == null)
            {
                return NotFound();
            }

            existingPost.Name = value.Name;
            existingPost.Description = value.Description;
            existingPost.Posted = DateTime.Now;

            var updatedPost = await _postService.UpdatePostAsync(existingPost);

            if (updatedPost == null)
            {
                return StatusCode(500, "Internal server error"); // Adjust the status code and message as needed
            }

            return Ok(updatedPost);
        }



        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
