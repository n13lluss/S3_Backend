using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelblog.Core.Interfaces;
using Travelblog.Dal.Entities;

namespace Travelblog.Dal.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly TravelBlogDbContext _dbContext;

        public BlogPostRepository(TravelBlogDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public void CreateBlogPost(int postId, int blogId)
        {
            BlogPost blogPost = new()
            {
                PostId = postId,
                BlogId = blogId
            };
            _dbContext.BlogPosts.Add(blogPost);
            _dbContext.SaveChanges();
        }

        public List<Core.Models.Post> GetAllBlogPosts(int BlogId)
        {
            var blogs = _dbContext.Blogs
                            .Where(blog => blog.Id == BlogId)
                            .Join(_dbContext.BlogPosts, blog => blog.Id, blogPost => blogPost.BlogId, (blog, blogPost) => blogPost)
                            .Join(_dbContext.Posts, blogPost => blogPost.PostId, post => post.Id, (blogPost, post) => post)
                            .ToList();


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

    }
}
