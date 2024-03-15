using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travelblog.Core.Interfaces;
using Travelblog.Dal.Entities;

namespace Travelblog.Dal.Repositories
{
    public class BlogPostRepository(TravelBlogDbContext dbContext) : IBlogPostRepository
    {
        private readonly TravelBlogDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task CreateBlogPostAsync(int postId, int blogId)
        {
            BlogPost blogPost = new()
            {
                PostId = postId,
                BlogId = blogId
            };
            _dbContext.BlogPosts.Add(blogPost);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Core.Models.Post>> GetAllBlogPostsAsync(int BlogId)
        {
            var blogs = await _dbContext.Blogs
                .Where(blog => blog.Id == BlogId)
                .Join(_dbContext.BlogPosts, blog => blog.Id, blogPost => blogPost.BlogId, (blog, blogPost) => blogPost)
                .Join(_dbContext.Posts, blogPost => blogPost.PostId, post => post.Id, (blogPost, post) => post)
                .ToListAsync();

            return blogs.Select(blog => MapToPost(blog)).ToList();
        }

        public static Core.Models.Post MapToPost(Entities.Post entity)
        {
            return entity != null
                ? new Core.Models.Post
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Likes = entity.Likes,
                    Posted = entity.PostedOn,
                    IsPrive = entity.Prive,
                    IsSuspended = entity.Suspended,
                    IsDeleted = entity.Deleted,
                    TripId = entity.TripId
                }
                : new Core.Models.Post();
        }

        public async Task DeleteBlogPostAsync(int postId)
        {
            var blogPost = await _dbContext.BlogPosts.FirstOrDefaultAsync(bp => bp.PostId == postId);

            if (blogPost != null)
            {
                _dbContext.BlogPosts.Remove(blogPost);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
