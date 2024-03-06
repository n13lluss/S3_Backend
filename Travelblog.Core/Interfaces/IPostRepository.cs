using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IPostRepository
    {
        Post GetPostByID(int id);
        List<Post> GetAllPostsByBlogId(int id);
        Post CreatePost(Post post);
        Post UpdatePost(Post post);
        Post DeletePost(int id);
    }
}
