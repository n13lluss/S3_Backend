using Travelblog.Core.Models;

namespace Travelblog.Core.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();
        Task<Country> GetCountryById(int id);
    }
}
