using Microsoft.EntityFrameworkCore;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Dal.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly TravelBlogDbContext _dbContext;

        public PostRepository(TravelBlogDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Post> GetAllPostsByBlogId(int id)
        {
            var collected = _dbContext.Posts.Where(p => p.TripId == id).ToList();
            return collected.Select(p => MapEntityToCoreModel(p)).ToList();
        }

        public Post GetPostByID(int id)
        {
            var collected = _dbContext.Posts.Find(id);
            return MapEntityToCoreModel(collected);
        }

        public Post CreatePost(Post post)
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

            _dbContext.Posts.Add(postEntity);

            try
            {
                _dbContext.SaveChanges();
                return MapEntityToCoreModel(postEntity);
            }
            catch (DbUpdateException ex)
            {
                // Handle the exception (log, rethrow, or return null)
                return null;
            }
        }

        public Post UpdatePost(Post post)
        {
            var existingPostEntity = _dbContext.Posts.FirstOrDefault(p => p.Id == post.Id);

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
                    _dbContext.SaveChanges();
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

        public Post DeletePost(int id)
        {
            var post = _dbContext.Posts.Find(id);
            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                _dbContext.SaveChanges();
            }
            return MapEntityToCoreModel(post);
        }

        private static Post MapEntityToCoreModel(Entities.Post entity)
        {
            return entity != null
                ? new Post
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
                : new Post();
        }
    }
}
