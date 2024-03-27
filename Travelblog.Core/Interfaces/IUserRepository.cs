using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        User GetById(string IdString);
        User GetByUserName(string userName);
        User GetByEmail(string email);
        User CreateUser(User user);
    }
}
