﻿using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> GetPostByIDAsync(int id);
        Task<List<Post>> GetAllPostsByBlogIdAsync(int id);
        Post CreatePostAsync(Post post, int blogid);
        Task<Post> UpdatePostAsync(Post post);
        Task<Post> DeletePostAsync(int id);
    }
}
