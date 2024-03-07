using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IBlogPostRepository _blogpostRepository;
        public BlogService(IBlogRepository blogRepository, IBlogPostRepository postRepository)
        {
            _repository = blogRepository;
            _blogpostRepository = postRepository;
        }
        public Blog CreateBlog(Blog blog)
        {
            if(blog.Description == null)
            {
                blog.Description = string.Empty;
            }
            return _repository.Create(blog);
        }

        public Blog UpdateBlog(Blog blog)
        {
            Blog UpdatedBlog = _repository.Update(blog);
            return UpdatedBlog;
        }

        public Blog GetBlogById(int id)
        {
            var blog = _repository.GetById(id);
            blog.Posts = _blogpostRepository.GetAllBlogPosts(id).OrderBy(post => post.Posted).ToList();
            return blog;
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
