using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public Task<List<Country>> GetAllCountries()
        {
            return _countryRepository.GetAllCountries();
        }

        public Task<Country> GetCountryById(int id)
        {
            return _countryRepository.GetCountryById(id);
        }
    }
}
