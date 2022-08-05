using Microsoft.AspNetCore.Mvc;
using QuoteRepo.Business.Abstract;

namespace QuoteRepo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesControllerWithService : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesControllerWithService(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryService.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _countryService.GetAsync(id);
            return Ok(country);
        }
    }
}
