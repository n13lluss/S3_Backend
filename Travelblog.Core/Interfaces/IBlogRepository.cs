using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetAll();
        Blog Create(Blog blog);
        Blog Update(Blog blog);
        Blog GetById(int id);
    }
}
