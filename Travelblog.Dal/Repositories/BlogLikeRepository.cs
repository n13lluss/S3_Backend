using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Dal.Repositories
{
    public class BlogLikeRepository(TravelBlogDbContext dbContext) : IBlogLikeRepository
    {
        private readonly TravelBlogDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public int GetLikes(Blog blog)
        {
            try
            {
                var count = _dbContext.BlogLikes.Where(b => b.BlogId == blog.Id && b.Status == true).Count();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public Blog LikeBlog(Blog blog, User user)
        {
            var exists = _dbContext.BlogLikes.FirstOrDefaultAsync(b => b.BlogId == blog.Id && b.UserId == user.Id);
            if (exists.Result == null)
            {
                var blogLike = new Entities.BlogLike
                {
                    BlogId = blog.Id,
                    UserId = user.Id,
                    Date = DateTime.Now,
                    Status = true,
                };
                _dbContext.BlogLikes.Add(blogLike);
                _dbContext.SaveChanges();
                blog.Likes++;
            }
            else if (exists.Result.Status == false)
            {
                exists.Result.Status = true;
                _dbContext.BlogLikes.Update(exists.Result);
            }
            else
            {
                return UnLikeBlog(blog, user);
            }
            return blog;
        }

        public bool Liked(Blog blog, User user)
        {
            try
            {
                var found = _dbContext.BlogLikes.FirstOrDefault(b => b.BlogId == blog.Id && b.UserId == user.Id && b.Status == true);
                return found != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Blog UnLikeBlog(Blog blog, User user)
        {
            try
            {
                // Check if the user has previously liked the blog
                var existingLike = _dbContext.BlogLikes
                    .FirstOrDefault(bl => bl.BlogId == blog.Id && bl.UserId == user.Id);

                if (existingLike != null)
                {
                    // Update the existing like record to set its status to false
                    existingLike.Status = false;
                    existingLike.Date = DateTime.Now;
                    _dbContext.SaveChanges();

                    // Update the blog's like count
                    blog.Likes--;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Handle the exception as needed
            }
            return blog;
        }
    }
}
