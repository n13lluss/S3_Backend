using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IBlogLikeRepository
    {
        public bool Liked(Blog blog, User user);
        public int GetLikes(Blog blog);
        public Blog LikeBlog(Blog blog, User user);
        public Blog UnLikeBlog(Blog blog, User user);
    }
}
