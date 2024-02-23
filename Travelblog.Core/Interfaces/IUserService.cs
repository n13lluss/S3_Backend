using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IUserService { 
        public User CreateUser(User user);
        public User UpdateUser(User user);
        public void DeleteUser(User user);
        public User GetUserById(int id);
        public User GetUserByName(string name);
        public User GetUserByEmail(string email);
    }
}
