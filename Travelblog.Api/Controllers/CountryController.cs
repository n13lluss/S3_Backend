using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Travelblog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        // GET: api/<CountryController>
        [HttpGet]
        public async Task<List<Country>> Get()
        {
            return await _countryService.GetAllCountries();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public async Task<Country> Get(int id)
        {
            return await _countryService.GetCountryById(id);
        }
    }
}
