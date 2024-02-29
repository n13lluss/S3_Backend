using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public string GetNameById(int UserId)
        {
            User user = GetById(UserId);
            return user.UserName;
        }
    }
}
