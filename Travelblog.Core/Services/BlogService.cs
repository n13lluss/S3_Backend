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
        public Blog CreateBlog(Blog blog)
        {
            return _repository.Create(blog);
        }

        public Blog UpdateBlog(Blog blog)
        {
            Blog UpdatedBlog = _repository.Update(blog);
            return UpdatedBlog;
        }

        public Blog GetBlogById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Blog> GetBlogList()
        {
            return _repository.GetAll();
        }

        public Blog AddCountry(Country country)
        {
            // Implement logic to add country to blog
            throw new NotImplementedException();
        }

        public Blog AddFollower(Blog blog, User user)
        {
            // Implement logic to add follower to blog
            throw new NotImplementedException();
        }

        public Blog AddPost(Post post)
        {
            // Implement logic to add post to blog
            throw new NotImplementedException();
        }

        public List<User> GetFollowers(int Id)
        {
            // Implement logic to get followers of a blog
            throw new NotImplementedException();
        }

        public Blog LikeBlog(Blog blog, User user)
        {
            // Implement logic to like a blog
            throw new NotImplementedException();
        }

        public Blog RemoveCountry(Country country)
        {
            // Implement logic to remove country from blog
            throw new NotImplementedException();
        }

        public Blog RemoveFollower(Blog blog, User user)
        {
            // Implement logic to remove follower from blog
            throw new NotImplementedException();
        }

        public Blog RestoreBlog(Blog blog)
        {
            // Implement logic to restore a suspended blog
            throw new NotImplementedException();
        }

        public Blog UnLikeBlog(Blog blog, User user)
        {
            // Implement logic to unlike a blog
            throw new NotImplementedException();
        }
    }
}
