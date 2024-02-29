﻿using Travelblog.Core.Interfaces;

namespace Travelblog.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TravelBlogDbContext _dbContext;

        public UserRepository(TravelBlogDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
