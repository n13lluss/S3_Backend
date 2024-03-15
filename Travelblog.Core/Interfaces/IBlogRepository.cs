using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAll();
        Blog Create(Blog blog);
        Task<Blog> Update(Blog blog);
        Task<Blog> GetById(int id);
    }
}
