using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        User GetByUserName(string userName);
        User GetByEmail(string email);
    }
}
