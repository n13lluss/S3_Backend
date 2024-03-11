using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IPostService
    {
        Task<Post> CreatePostAsync(Post post, int BlogId);
        Task<Post> UpdatePostAsync(Post post);
        Task<Post> DeletePostAsync(Post post);
        Task<Post> GetPostByIdAsync(int id);
    }
}
