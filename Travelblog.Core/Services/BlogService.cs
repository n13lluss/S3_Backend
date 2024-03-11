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
            if (blog == null)
            {
                throw new ArgumentNullException(nameof(blog));
            }

            if (string.IsNullOrEmpty(blog.Name))
            {
                throw new ArgumentException("Blog title cannot be empty", nameof(blog.Name));
            }

            try
            {
                return _repository.Create(blog);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating blog", ex);
            }
        }

        public Blog UpdateBlog(Blog blog)
        {
            if (blog == null)
            {
                throw new ArgumentNullException(nameof(blog));
            }

            if (string.IsNullOrEmpty(blog.Name))
            {
                throw new ArgumentException("Blog title cannot be empty", nameof(blog.Name));
            }

            try
            {
                Blog updatedBlog = _repository.Update(blog);
                return updatedBlog;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating blog", ex);
            }
        }

        public Blog GetBlogById(int id)
        {
            if(id < 0)
            {
                throw new Exception("Invalid id");
            }
            try
            {
                var blog = _repository.GetById(id);
                if(blog == null)
                {
                    throw new Exception("Not found");
                }
                blog.Posts = _blogpostRepository.GetAllBlogPosts(id).OrderBy(post => post.Posted).ToList();
                return blog;
            }
            catch(Exception ex)
            {
                throw new Exception("Unable to get Blog", ex);
            }
            
        }


        public List<Blog> GetBlogList()
        {
            
            var blogs = _repository.GetAll();
            if(blogs == null || blogs.Count == 0)
            {
                throw new Exception("Error in getting data");
            }
            return blogs;
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
