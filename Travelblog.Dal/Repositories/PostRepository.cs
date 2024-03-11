using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;
using Travelblog.Dal.Entities;

namespace Travelblog.Dal.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly TravelBlogDbContext _dbContext;
        private readonly IBlogPostRepository _blogPostRepository;

        public PostRepository(TravelBlogDbContext dbContext, IBlogPostRepository blogPostRepository)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _blogPostRepository = blogPostRepository ?? throw new ArgumentNullException(nameof(blogPostRepository));
        }

        public async Task<List<Core.Models.Post>> GetAllPostsByBlogIdAsync(int id)
        {
            var collected = await _dbContext.Posts.Where(p => p.TripId == id).ToListAsync();
            return collected.Select(p => MapEntityToCoreModel(p)).ToList();
        }

        public async Task<Core.Models.Post> GetPostByIDAsync(int id)
        {
            var collected = await _dbContext.Posts.FindAsync(id);
            return MapEntityToCoreModel(collected);
        }

        public async Task<Core.Models.Post> CreatePostAsync(Core.Models.Post post, int blogid)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var postEntity = new Entities.Post
                    {
                        Name = post.Name,
                        Description = post.Description,
                        Likes = post.Likes,
                        Prive = post.IsPrive,
                        Suspended = post.IsSuspended,
                        Deleted = post.IsDeleted,
                        PostedOn = post.Posted,
                        TripId = 3
                    };

                    await _dbContext.Posts.AddAsync(postEntity);
                    await _dbContext.SaveChangesAsync();

                    await _blogPostRepository.CreateBlogPostAsync(postEntity.Id, blogid);

                    await transaction.CommitAsync();

                    return MapEntityToCoreModel(postEntity);
                }
                catch (DbUpdateException ex)
                {
                    // Handle the exception (log, rethrow, or return null)
                    await transaction.RollbackAsync();
                    return null;
                }
            }
        }

        public async Task<Core.Models.Post> UpdatePostAsync(Core.Models.Post post)
        {
            var existingPostEntity = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == post.Id);

            if (existingPostEntity != null)
            {
                existingPostEntity.Name = post.Name;
                existingPostEntity.Description = post.Description;
                existingPostEntity.Likes = post.Likes;
                existingPostEntity.Prive = post.IsPrive;
                existingPostEntity.Suspended = post.IsSuspended;
                existingPostEntity.Deleted = post.IsDeleted;
                existingPostEntity.PostedOn = post.Posted;
                existingPostEntity.TripId = post.TripId;

                try
                {
                    await _dbContext.SaveChangesAsync();
                    return MapEntityToCoreModel(existingPostEntity);
                }
                catch (DbUpdateException ex)
                {
                    // Handle the exception (log, rethrow, or return null)
                    return null;
                }
            }

            return null;
        }

        public async Task<Core.Models.Post> DeletePostAsync(int id)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var post = await _dbContext.Posts.FindAsync(id);
                    if (post != null)
                    {
                        _dbContext.Posts.Remove(post);
                        await _dbContext.SaveChangesAsync();

                        // Now delete the associated blog post
                        await _blogPostRepository.DeleteBlogPostAsync(id);
                    }

                    await transaction.CommitAsync();

                    return MapEntityToCoreModel(post);
                }
                catch (DbUpdateException ex)
                {
                    // Handle the exception (log, rethrow, or return null)
                    await transaction.RollbackAsync();
                    return null;
                }
            }
        }

        private static Core.Models.Post MapEntityToCoreModel(Entities.Post entity)
        {
            return entity != null
                ? new Core.Models.Post
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Likes = entity.Likes,
                    IsPrive = entity.Prive,
                    IsSuspended = entity.Suspended,
                    IsDeleted = entity.Deleted,
                    Posted = entity.PostedOn,
                    TripId = entity.TripId
                }
                : new Core.Models.Post();
        }
    }
}
