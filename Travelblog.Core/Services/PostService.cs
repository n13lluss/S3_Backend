using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IBlogService _blogService;
        private readonly IBlogPostRepository _blogPostRepository;
        public PostService(IPostRepository postRepository, IBlogService blogService, IBlogPostRepository blogPostRepository) {
            _postRepository = postRepository;
            _blogService = blogService;
            _blogPostRepository = blogPostRepository;
        }
        public Post CreatePost(Post post, int BlogId)
        {
            if (post == null)
            {
                throw new ArgumentException("Invalid post");
            }

            try
            {
                Post created = _postRepository.CreatePost(post);

                if (created == null)
                {
                    throw new Exception("Error creating post");
                }

                _blogPostRepository.CreateBlogPost(created.Id, BlogId);
                return created;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to create post", ex);
            }
        }

        public Post DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Post UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
