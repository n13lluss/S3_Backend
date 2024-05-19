using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelblog.Core.Interfaces
{
    public interface IBlogCountryRepository
    {
        Task<List<Core.Models.Country>> GetCountriesByBlog(int blogId);
    }
}
