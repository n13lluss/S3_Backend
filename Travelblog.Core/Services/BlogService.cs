using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Core.Services
{
    public class BlogService(IBlogRepository blogRepository, IBlogLikeRepository blogLikeRepository, IBlogCountryRepository blogCountryRepository) : IBlogService
    {
        private readonly IBlogRepository _blogrepository = blogRepository;
        private readonly IBlogCountryRepository _blogCountryRepository = blogCountryRepository;
        private readonly IBlogLikeRepository _blogLikeRepository = blogLikeRepository;

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
                return _blogrepository.Create(blog);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating blog", ex);
            }
        }

        public async Task<Blog> UpdateBlog(Blog blog)
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
                Blog updatedBlog = await _blogrepository.Update(blog);
                return updatedBlog;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating blog", ex);
            }
        }

        public async Task<Blog> GetBlogById(int id)
        {
            if (id < 0)
            {
                throw new Exception("Invalid id");
            }

            try
            {
                var blog = await _blogrepository.GetById(id);
                blog.Likes = _blogLikeRepository.GetLikes(blog);
                return blog;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Blog", ex);
            }
        }

        public async Task<List<Blog>> GetBlogList()
        {
            var blogs = await _blogrepository.GetAll();
            if (blogs == null || blogs.Count == 0)
            {
                throw new Exception("Error in getting data");
            }
            foreach (var blog in blogs)
            {
                blog.Likes = _blogLikeRepository.GetLikes(blog);
                blog.Countries = await _blogCountryRepository.GetCountriesByBlog(blog.Id);
            }
            return blogs;
        }

        public Blog AddFollower(Blog blog, User user)
        {
            // Implement logic to add follower to blog
            throw new NotImplementedException();
        }

        public List<User> GetFollowers(int Id)
        {
            // Implement logic to get followers of a blog
            throw new NotImplementedException();
        }

        public Blog LikeBlog(Blog blog, User user)
        {
            if (blog == null || user == null)
            {
                throw new ArgumentNullException(nameof(blog));
            }
            try
            {
                var liked = _blogLikeRepository.Liked(blog, user);
                if (!liked)
                {
                    blog = _blogLikeRepository.LikeBlog(blog, user);
                    _blogrepository.Update(blog);
                }
                else
                {
                    return UnLikeBlog(blog, user);
                }
                return blog;
            }
            catch (Exception ex)
            {
                throw new Exception("Error liking blog", ex);
            }
        }

        public Blog RemoveFollower(Blog blog, User user)
        {
            // Implement logic to remove follower from blog
            throw new NotImplementedException();
        }

        public Blog UnLikeBlog(Blog blog, User user)
        {
            if (blog == null || user == null)
            {
                throw new ArgumentNullException(nameof(blog));
            }
            try
            {
                _blogLikeRepository.UnLikeBlog(blog, user);
                _blogrepository.Update(blog);
                return blog;
            }
            catch (Exception ex)
            {
                throw new Exception("Error unliking blog", ex);
            }
        }

        public bool Liked(Blog blog, User user)
        {
            if(blog == null || user == null)
            {
                throw new ArgumentNullException(nameof(blog));
            }
            try
            {
                return _blogLikeRepository.Liked(blog, user);
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking if blog is liked", ex);
            }
        }

        public async Task<Blog> AddCountries(Blog blog, List<Country> countries)
        {
            if(blog == null || countries == null)
            {
                throw new ArgumentException("Invalid blog id or country");
            }
            
            blog.Countries = countries;
            try
            {
                return await _blogrepository.Update(blog);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding countries to blog", ex);
            }   
        }

        public async Task<Blog> RemoveCountry(Blog blog, Country country)
        {
            throw new NotImplementedException();
        }
    }
}
