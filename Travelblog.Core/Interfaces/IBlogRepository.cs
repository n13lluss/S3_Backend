using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAll();
        Task<Blog> Create(Blog blog);
        Task<Blog> Update(Blog blog);
        Task<Blog> GetById(int id);
        Task<int> BlogsCreatedToday(string IdString);
    }
}
