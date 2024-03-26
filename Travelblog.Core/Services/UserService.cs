using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Core.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public bool CheckAvailability(User user)
        {
            if(user == null)
            {
                return false;
            }

            var exist = _userRepository.GetByUserName(user.UserName) != null || _userRepository.GetByEmail(user.Email) != null;

            if(exist)
            {
                return false;
            }

            return true;
        }

        public bool CheckUser(string usernameEmail, string enteredPassword)
        {
            User foundUser;
            if (usernameEmail.Contains('@'))
            {
                foundUser = _userRepository.GetByEmail(usernameEmail);
            }
            else
            {
                foundUser = _userRepository.GetByUserName(usernameEmail);
            }

            if (foundUser == null)
            {
                return false; // User not found
            }
            
            bool valid = BCrypt.Net.BCrypt.Verify(foundUser.Password, BCrypt.Net.BCrypt.HashPassword(foundUser.Password));

            // Compare decrypted entered password with stored password
            bool passwordIsValid = foundUser.Password == enteredPassword;

            return valid;
        }      


        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public string GetNameById(int UserId)
        {
            User user = GetById(UserId);
            return user == null ? throw new Exception("User not found") : user.UserName;
        }

        public User GetUserByName(string name)
        {
            return _userRepository.GetByUserName(name);
        }

        public bool RegisterUser(User user)
        {
            return _userRepository.CreateUser(user) != null;
        }
    }
}
