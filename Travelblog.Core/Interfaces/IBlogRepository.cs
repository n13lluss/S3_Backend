using System.Collections.Generic;
using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetAll();
        Blog Create(Blog blog);
        Blog Update(Blog blog);
        Blog GetById(int id);

        // Other methods like Delete, AddCountry, AddFollower, etc. can be added to match your requirements
    }
}
