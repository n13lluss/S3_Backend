using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Post created = _postRepository.CreatePost(post);
            _blogPostRepository.CreateBlogPost(created.Id, BlogId);
            return created;
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
