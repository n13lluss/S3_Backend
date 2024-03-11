using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IBlogPostRepository _blogPostRepository;
        public PostService(IPostRepository postRepository, IBlogPostRepository blogPostRepository) {
            _postRepository = postRepository;

            _blogPostRepository = blogPostRepository;
        }
        public async Task<Post> CreatePostAsync(Post post, int blogId)
        {
            if (post == null)
            {
                throw new ArgumentException("Invalid post");
            }

            try
            {
                Post createdPost = await _postRepository.CreatePostAsync(post, blogId);

                if (createdPost == null)
                {
                    throw new Exception("Error creating post");
                }
                return createdPost;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to create post", ex);
            }
        }

        public async Task<Post> DeletePostAsync(Post post)
        {
            if (post == null)
            {
                throw new ArgumentException("Invalid post");
            }

            try
            {
                await _blogPostRepository.DeleteBlogPostAsync(post.Id);
                return await _postRepository.DeletePostAsync(post.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to delete post", ex);
            }
        }

        public Task<Post> GetPostByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {
            if (post == null)
            {
                throw new ArgumentException("Invalid post");
            }

            try
            {
                return await _postRepository.UpdatePostAsync(post);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to update post", ex);
            }
        }
    }
}
