﻿using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Core.Services
{
    public class PostService(IPostRepository postRepository, IBlogPostRepository blogPostRepository) : IPostService
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;

        public async Task<Post> CreatePostAsync(Post post, int blogId)
        {
            if (post == null)
            {
                throw new ArgumentException("Invalid post");
            }

            if (await _postRepository.PostsCreatedToday(blogId) >= 5)
            {
                throw new Exception("Unable to make post because of limit");
            }

            try
            {
                Post createdPost = await _postRepository.CreatePostAsync(post, blogId);

                return createdPost ?? throw new Exception("Error creating post");
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to create post", ex);
            }
        }


        public async Task<Post> DeletePostAsync(Post post)
        {
            if (post == null)
            {
                throw new ArgumentException("Invalid post");
            }

            try
            {
                await _blogPostRepository.DeleteBlogPostAsync(post.Id);
                return await _postRepository.DeletePostAsync(post.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to delete post", ex);
            }
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("Invalid post id");
            }
            try
            {
                var post = await _postRepository.GetPostByIDAsync(id);
                return post ?? throw new Exception("Post not found");

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get post", ex);
            }
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {
            if (post == null)
            {
                throw new ArgumentException("Invalid post");
            }

            try
            {
                return await _postRepository.UpdatePostAsync(post);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to update post", ex);
            }
        }
    }
}
