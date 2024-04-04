using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IBlogService
    {
        public Blog CreateBlog(Blog blog);
        public Task<Blog> UpdateBlog(Blog blog);
        public Task<List<Blog>> GetBlogList();
        public Task<Blog> GetBlogById(int id);
        public Blog LikeBlog(Blog blog, User user);
        public Blog UnLikeBlog(Blog blog, User user);
        public bool Liked(Blog blog, User user);
        public Blog AddFollower(Blog blog, User user);
        public Blog RemoveFollower(Blog blog, User user);
        public List<User> GetFollowers(int BlogId);
        public Task<Blog> AddCountries(Blog blog, List<Country> country);
    }
}
