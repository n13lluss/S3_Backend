using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        public BlogService(IBlogRepository blogRepository) {
            _repository = blogRepository;
        }
        public Blog AddCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public Blog AddFollower(Blog blog, User user)
        {
            throw new NotImplementedException();
        }

        public Blog AddPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Blog CreateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Blog GetBlogById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogList()
        {
            return _repository.GetAll();
        }

        public List<User> GetFollowers(int Id)
        {
            throw new NotImplementedException();
        }

        public Blog LikeBlog(Blog blog, User user)
        {
            throw new NotImplementedException();
        }

        public Blog RemoveCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public Blog RemoveFollower(Blog blog, User user)
        {
            throw new NotImplementedException();
        }

        public Blog RestoreBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Blog UnLikeBlog(Blog blog, User user)
        {
            throw new NotImplementedException();
        }

        public Blog UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
