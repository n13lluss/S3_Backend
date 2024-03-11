using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IBlogPostRepository
    {
        Task CreateBlogPostAsync(int postId, int blogId);
        Task<List<Post>> GetAllBlogPostsAsync(int BlogId);
        Task DeleteBlogPostAsync(int postId);
    }
}
