using Azure;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Dal.Repositories
{
    public class UserRepository(TravelBlogDbContext dbContext) : IUserRepository
    {
        private readonly TravelBlogDbContext _dbContext = dbContext;

        public User CreateUser(User user)
        {
            Entities.User userEntity = new()
            {
                Username = user.UserName,
                Password = user.Password,
                IdString = user.IdString,
                Email = user.Email,
                Suspended = user.Suspended,
                Deleted = false,
                Role = "User"
            };

            try
            {
                _dbContext.Users.Add(userEntity);
                _dbContext.SaveChanges();
            }
            catch
            {
                return null;
            }
            return user; 
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
                    Email = user.Email,
                    IdString = user.IdString

                };
            }

            return new Core.Models.User();
        }

        public User GetById(string IdString)
        {
            try
            {
                var response = _dbContext.Users.FirstOrDefault(u => u.IdString == IdString);
                User user = new User()
                {
                    Id = response.Id,
                    UserName = response.Username,
                    Email = response.Email,
                    IdString = response.IdString
                };
                return user;
            }
            catch
            {
                return null;
            }
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
