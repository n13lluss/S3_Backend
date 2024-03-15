using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Drawing;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;
using Travelblog.Dal.Entities;
using Blog = Travelblog.Core.Models.Blog;

namespace Travelblog.Dal.Repositories
{
    public class BlogRepository(TravelBlogDbContext dbContext, IPostRepository postrepository, IBlogPostRepository blogPostRepository) : IBlogRepository
    {
        private readonly TravelBlogDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        private readonly IPostRepository _postRepository = postrepository;
        private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;

        public async Task<List<Blog>> GetAll()
        {
            var blogs = await _dbContext.Blogs.ToListAsync();
            List<Blog> result = blogs.Select(blog => MapEntityToCoreModel(blog)).ToList();
            return result;
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
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Blog> Update(Blog blog)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
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

                    if (blog.IsDeleted == true)
                    {
                        try
                        {
                            foreach (Core.Models.Post post in blog.Posts)
                            {
                                post.IsDeleted = true;
                                _postRepository.UpdatePostAsync(post);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception (log, rethrow, or return null)
                            transaction.Rollback();
                            return null;
                        }
                    }

                    _dbContext.SaveChanges();
                    transaction.Commit();

                    return MapEntityToCoreModel(existingBlogEntity);
                }
                transaction.Rollback();
                return null;
            }
            catch (DbUpdateException ex)
            {
                transaction.Rollback();
                return null;
            }
        }

        public async Task<Blog> GetById(int id)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var blogEntity = _dbContext.Blogs.FirstOrDefault(blog => blog.Id == id);
                Blog found = MapEntityToCoreModel(blogEntity);
                found.Posts = await _blogPostRepository.GetAllBlogPostsAsync(id);
                found.Posts = [.. found.Posts.OrderBy(post => post.Posted)];
                await transaction.CommitAsync();
                return found;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Unable to get Blog", ex);
            }
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
