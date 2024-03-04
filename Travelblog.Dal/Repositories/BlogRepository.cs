using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;
using Travelblog.Core.Services;

namespace Travelblog.Dal.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly TravelBlogDbContext _dbContext;

        public BlogRepository(TravelBlogDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Blog> GetAll()
        {
            var blogs = _dbContext.Blogs.ToList();
            List<Blog> result = blogs.Select(blog => MapEntityToCoreModel(blog)).ToList();
            return result;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _dbContext.Blogs
                .Select(blogEntity => MapEntityToCoreModel(blogEntity))
                .ToListAsync();
        }

        public Blog Create(Blog blog)
        {
            var blogEntity = new Entities.Blog
            {
                CreatorId = blog.User_Id,
                Name = blog.Name,
                Description = blog.Description,
                StartDate = blog.StartDate,
                Likes = blog.Likes,
                Prive = blog.IsPrive,
                Suspended = blog.IsSuspended,
                Deleted = blog.IsDeleted,
                TripId = null
            };

            _dbContext.Blogs.Add(blogEntity);

            try
            {
                _dbContext.SaveChanges();
                return MapEntityToCoreModel(blogEntity);
            }
            catch (DbUpdateException ex)
            {
                return null;
            }
        }

        public Blog Update(Blog blog)
        {
            var existingBlogEntity = _dbContext.Blogs.FirstOrDefault(b => b.Id == blog.Id);

            if (existingBlogEntity != null)
            {
                existingBlogEntity.Name = blog.Name;
                existingBlogEntity.StartDate = blog.StartDate;
                existingBlogEntity.Likes = blog.Likes;
                existingBlogEntity.Prive = blog.IsPrive;
                existingBlogEntity.Suspended = blog.IsSuspended;
                existingBlogEntity.Deleted = blog.IsDeleted;
                existingBlogEntity.Description = blog.Description;
                existingBlogEntity.TripId = null;

                try
                {
                    _dbContext.SaveChanges();
                    return MapEntityToCoreModel(existingBlogEntity);
                }
                catch (DbUpdateException ex)
                {
                    // Handle the exception (log, rethrow, or return null)
                    return null;
                }
            }

            return null;
        }

        public Blog GetById(int id)
        {
            var blogEntity = _dbContext.Blogs.FirstOrDefault(blog => blog.Id == id);
            return MapEntityToCoreModel(blogEntity);
        }

        private static Blog MapEntityToCoreModel(Entities.Blog entity)
        {
            return entity != null
                ? new Blog
                {
                    Id = entity.Id,
                    User_Id = entity.CreatorId,
                    Name = entity.Name,
                    Description = entity.Description,
                    Likes = entity.Likes,
                    StartDate = entity.StartDate,
                    IsPrive = entity.Prive,
                    IsSuspended = entity.Suspended,
                    IsDeleted = entity.Deleted
                }
                : new Blog();
        }

    }
}
