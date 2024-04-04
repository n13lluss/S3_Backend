using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;
using Travelblog.Dal.Entities; // Make sure to import the Entities namespace

namespace Travelblog.Dal.Repositories
{
    public class BlogCountryRepository : IBlogCountryRepository // Removed parentheses after class name
    {
        private readonly TravelBlogDbContext _dbContext;

        public BlogCountryRepository(TravelBlogDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Core.Models.Country>> GetCountriesByBlog(int blogId)
        {
            var blogs = _dbContext.Blogs
                        .Where(b => b.Id == blogId)
                        .Join(
                            _dbContext.BlogCountries,
                            b => b.Id,
                            bc => bc.BlogId,
                            (b, bc) => bc
                        )
                        .Join(
                            _dbContext.Countries,
                            bc => bc.CountryId,
                            c => c.Id,
                            (bc, c) => c
                        )
                        .ToList();

            return blogs.Select(ToCoreModel).ToList(); // Use ToList() to return List<Country>
        }

        static Core.Models.Country ToCoreModel(Dal.Entities.Country entity) // Adjust parameter type to match the Entities namespace
        {
            return new Core.Models.Country
            {
                Id = entity.Id,
                Name = entity.Name,
                Continent = entity.Continent
            };
        }
    }
}
