using CountryDataDotnetDemo.API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CountryDataDotnetDemo.API.Controllers
{
    /// <summary>
    /// Controller for handling country data related requests.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CountryDataController : ControllerBase
    {
        private readonly ICountryDataServices _countryDataServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryDataController"/> class.
        /// </summary>
        /// <param name="countryDataServices">The country data services.</param>
        public CountryDataController(ICountryDataServices countryDataServices)
        {
            _countryDataServices = countryDataServices;
        }

        /// <summary>
        /// Gets the list of countries.
        /// </summary>
        /// <returns>A list of countries.</returns>
        [HttpGet]
        [Route("countries")]
        public async Task<IActionResult> GetCountriesAsync()
        {
            var countries = await _countryDataServices.GetCountriesAsync();
            return Ok(countries);
        }

        /// <summary>
        /// Gets the country by its code.
        /// </summary>
        /// <param name="code">The country code.</param>
        /// <returns>The country details.</returns>
        [HttpGet]
        [Route("country/{code}")]
        public async Task<IActionResult> GetCountryByCodeAsync(string code)
        {
            var country = await _countryDataServices.GetCountryByCodeAsync(code);
            return Ok(country);
        }

        /// <summary>
        /// Gets the country data with pagination and optional search query.
        /// </summary>
        /// <param name="offset">The offset for pagination.</param>
        /// <param name="limit">The limit for pagination.</param>
        /// <param name="searchQuery">The optional search query.</param>
        /// <returns>The paginated country data.</returns>
        [HttpGet]
        [Route("countrydata")]
        public async Task<IActionResult> GetCountryDataAsync([FromQuery] int offset = 1, [FromQuery] int limit = 5, string? searchQuery = null)
        {
            var countryData = await _countryDataServices.GetCountryDataAsync(offset, limit, searchQuery);
            return Ok(countryData);
        }

        /// <summary>
        /// Gets the regions by country code.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>The list of regions.</returns>
        [HttpGet]
        [Route("regions/{countryCode}")]
        public async Task<IActionResult> GetRegionsByCountryCodeAsync(string countryCode)
        {
            var regions = await _countryDataServices.GetRegionsByCountryCodeAsync(countryCode);
            return Ok(regions);
        }

        /// <summary>
        /// Gets the country flag by country code.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>The country flag.</returns>
        [HttpGet]
        [Route("flag/{countryCode}")]
        public async Task<IActionResult> GetCountryFlagAsync(string countryCode)
        {
            var flag = await _countryDataServices.GetCountryFlagAsync(countryCode);
            return Ok(flag);
        }

        /// <summary>
        /// Gets the phone code by country short code.
        /// </summary>
        /// <param name="countryCode">The country short code.</param>
        /// <returns>The phone code.</returns>
        [HttpGet]
        [Route("phonecode/{countryCode}")]
        public async Task<IActionResult> GetPhoneCodeByCountryShortCodeAsync(string countryCode)
        {
            var phoneCode = await _countryDataServices.GetPhoneCodeByCountryShortCodeAsync(countryCode);
            return Ok(phoneCode);
        }

        /// <summary>
        /// Gets the country by phone code.
        /// </summary>
        /// <param name="phoneCode">The phone code.</param>
        /// <returns>The country details.</returns>
        [HttpGet]
        [Route("countrybyphonecode/{phoneCode}")]
        public async Task<IActionResult> GetCountryByPhoneCodeAsync(string phoneCode)
        {
            var country = await _countryDataServices.GetCountryByPhoneCodeAsync(phoneCode);
            return Ok(country);
        }
    }
}
