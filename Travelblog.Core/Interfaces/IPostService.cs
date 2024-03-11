using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IPostService
    {
        Post CreatePost(Post post, int BlogId);
        Post UpdatePost(Post post);
        Post DeletePost(Post post);
    }
}
