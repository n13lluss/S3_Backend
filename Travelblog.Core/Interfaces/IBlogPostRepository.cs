using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IBlogPostRepository
    {
        void CreateBlogPost(int postId, int blogId);
        List<Post> GetAllBlogPosts(int BlogId);
    }
}
