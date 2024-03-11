using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TravelBlogDbContext _dbContext;

        public UserRepository(TravelBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetByEmail(string email)
        {
            Entities.User user = _dbContext.Users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                return new Core.Models.User
                {
                    Id = user.Id,
                    UserName = user.Username,
                    Email = user.Email
                };
            }

            return null;
        }

        public Core.Models.User GetById(int id)
        {
            Entities.User user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                return new Core.Models.User
                {
                    Id = user.Id,
                    UserName = user.Username,
                    Email = user.Email
                };
            }

            return new Core.Models.User();
        }

        public User GetByUserName(string userName)
        {
            Entities.User user = _dbContext.Users.FirstOrDefault(u => u.Username == userName);

            if (user != null)
            {
                return new Core.Models.User
                {
                    Id = user.Id,
                    UserName = user.Username,
                    Email = user.Email,
                    Password = user.Password
                };
            }

            return null;
        }
    }
}
