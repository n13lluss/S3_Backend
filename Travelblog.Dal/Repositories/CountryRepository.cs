using Microsoft.EntityFrameworkCore;
using Travelblog.Core.Interfaces;

namespace Travelblog.Dal.Repositories
{
    public class CountryRepository(TravelBlogDbContext dbContext) : ICountryRepository
    {
        private readonly TravelBlogDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<List<Core.Models.Country>> GetAllCountries()
        {
            var entities = await _dbContext.Countries.ToListAsync();
            return entities.Select(MapToModel).ToList();
        }

        public async Task<Core.Models.Country> GetCountryById(int id)
        {
            var entitie = await _dbContext.Countries.FirstOrDefaultAsync(c => c.Id == id);
            return MapToModel(entitie);
        }

        private Core.Models.Country MapToModel(Dal.Entities.Country entity)
        {
            return new Core.Models.Country
            {
                Id = entity.Id,
                Name = entity.Name,
                Continent = entity.Continent,
            };
        }
    }
}
