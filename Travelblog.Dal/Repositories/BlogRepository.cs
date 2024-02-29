using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Dal.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly TravelBlogDbContext _dbContext;

        public BlogRepository(TravelBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Blog> GetAll()
        {
            // Perform the conversion from entity to core model
            return _dbContext.Blogs.Select(blogEntity => new Blog
            {
                // Map properties accordingly
                Id = blogEntity.Id,
                User_Id = blogEntity.CreatorId,
                Name = blogEntity.Name,
                StartDate = blogEntity.StartDate,
                Likes = blogEntity.Likes,
                IsPrive = blogEntity.Prive,
                IsSuspended = blogEntity.Suspended,
                IsDeleted = blogEntity.Deleted,
            }).ToList();
        }

        public Blog Create(Blog blog)
        {
            // Convert from core model to entity
            var blogEntity = new Entities.Blog
            {
                // Map properties accordingly
                CreatorId = blog.User_Id,
                Name = blog.Name,
                StartDate = blog.StartDate,
                Likes = blog.Likes,
                Prive = blog.IsPrive,
                Suspended = blog.IsSuspended,
                Deleted = blog.IsDeleted,
                TripId = blog.Trip_Id // Adjust as needed
            };

            // Add to the database context and save changes
            _dbContext.Blogs.Add(blogEntity);
            _dbContext.SaveChanges();

            // Return the updated entity
            return MapEntityToCoreModel(blogEntity);
        }

        public Blog Update(Blog blog)
        {
            // Find the existing blog entity
            var existingBlogEntity = _dbContext.Blogs.Find(blog.Id);

            if (existingBlogEntity != null)
            {
                // Update properties accordingly
                existingBlogEntity.Name = blog.Name;
                existingBlogEntity.StartDate = blog.StartDate;
                existingBlogEntity.Likes = blog.Likes;
                existingBlogEntity.Prive = blog.IsPrive;
                existingBlogEntity.Suspended = blog.IsSuspended;
                existingBlogEntity.Deleted = blog.IsDeleted;
                existingBlogEntity.TripId = null; // Adjust as needed

                // Save changes
                _dbContext.SaveChanges();

                // Return the updated entity
                return MapEntityToCoreModel(existingBlogEntity);
            }

            return null; // Blog not found
        }

        public Blog GetById(int id)
        {
            // Find and return the blog entity by id
            var blogEntity = _dbContext.Blogs.Find(id);
            return MapEntityToCoreModel(blogEntity);
        }

        // Other methods like Delete, AddCountry, AddFollower, etc. can be implemented similarly

        private Blog MapEntityToCoreModel(Entities.Blog entity)
        {
            if (entity == null)
                return null;

            return new Blog
            {
                Id = entity.Id,
                User_Id = entity.CreatorId,
                Name = entity.Name,
                Likes = entity.Likes,
                StartDate = entity.StartDate,
                IsPrive = entity.Prive,
                IsSuspended = entity.Suspended,
                IsDeleted = entity.Deleted
            };
        }
    }
}
