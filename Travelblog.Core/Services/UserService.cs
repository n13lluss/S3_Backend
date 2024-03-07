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

        public bool CheckUser(string UsernameEmail, string Password)
        {
            User FoundUser;
            if(UsernameEmail.Contains("@"))
            {
                FoundUser = _userRepository.GetByEmail(UsernameEmail);
            }
            else
            {
                FoundUser = _userRepository.GetByUserName(UsernameEmail);
            }

            if(FoundUser == null || FoundUser.Password != Password)
            {
                return false;
            }
            
            return true;
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
