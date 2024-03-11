using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IBlogPostRepository
    {
        void CreateBlogPost(int postId, int blogId);
        List<Post> GetAllBlogPosts(int BlogId);
    }
}
