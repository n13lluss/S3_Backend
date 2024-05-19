using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface ICountryService
    {
        public Task<List<Country>> GetAllCountries();
        public Task<Country> GetCountryById(int id);
    }
}
