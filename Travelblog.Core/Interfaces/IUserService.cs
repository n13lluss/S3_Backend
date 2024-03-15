using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IUserService { 
        public User GetById(int id);
        public string GetNameById(int UserId);
        public bool CheckUser(string UsernameEmail,  string Password);
    }
}
