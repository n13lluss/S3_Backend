using Travelblog.Core.Interfaces;

namespace Travelblog.Dal.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly TravelBlogDbContext _dbContext;

        public BlogRepository(TravelBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Core.Models.Blog> GetAll()
        {
            // Perform the conversion from entity to core model
            return _dbContext.Blogs.Select(blogEntity => new Core.Models.Blog
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
                Trip_Id = 0 // Adjust as needed
            }).ToList();
        }
    }
}
