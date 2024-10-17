using CountryData.Standard;
using CountryDataDotnetDemo.API.Interface;
using Newtonsoft.Json;

namespace CountryDataDotnetDemo.API.Services
{
    /// <summary>
    /// Provides services for retrieving country data.
    /// </summary>
    public class CountryDataServices : ICountryDataServices, IDisposable
    {
        private readonly CountryHelper _countryHelper;
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryDataServices"/> class.
        /// </summary>
        /// <param name="countryHelper">The country helper instance.</param>
        public CountryDataServices(CountryHelper countryHelper)
        {
            _countryHelper = countryHelper;
        }

        /// <summary>
        /// Gets the list of countries asynchronously.
        /// </summary>
        /// <returns>A JSON string representing the list of countries.</returns>
        public Task<string> GetCountriesAsync()
        {
            var countries = _countryHelper.GetCountries();
            if (countries == null)
            {
                return Task.FromResult("No countries found");
            }

            return Task.FromResult(JsonConvert.SerializeObject(countries, Formatting.Indented));
        }

        /// <summary>
        /// Gets the country by its code asynchronously.
        /// </summary>
        /// <param name="code">The country code.</param>
        /// <returns>A JSON string representing the country.</returns>
        public Task<string> GetCountryByCodeAsync(string code)
        {
            var country = _countryHelper.GetCountryByCode(code);
            if (country == null)
            {
                return Task.FromResult("Country not found");
            }

            return Task.FromResult(JsonConvert.SerializeObject(country, Formatting.Indented));
        }

        /// <summary>
        /// Gets the country by its phone code asynchronously.
        /// </summary>
        /// <param name="phoneCode">The phone code.</param>
        /// <returns>A JSON string representing the country.</returns>
        public Task<string> GetCountryByPhoneCodeAsync(string phoneCode)
        {
            var country = _countryHelper.GetCountryByPhoneCode(phoneCode);
            if (country == null)
            {
                return Task.FromResult("Country not found");
            }

            return Task.FromResult(JsonConvert.SerializeObject(country, Formatting.Indented));
        }

        /// <summary>
        /// Gets the country data asynchronously.
        /// </summary>
        /// <returns>A JSON string representing the country data.</returns>
        public Task<string> GetCountryDataAsync()
        {
            var countryData = _countryHelper.GetCountryData();
            if (countryData == null)
            {
                return Task.FromResult("No country data found");
            }

            return Task.FromResult(JsonConvert.SerializeObject(countryData, Formatting.Indented));
        }

        /// <summary>
        /// Gets the country flag by its code asynchronously.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>A string representing the country flag.</returns>
        public Task<string> GetCountryFlagAsync(string countryCode)
        {
            var flag = _countryHelper.GetCountryEmojiFlag(countryCode);
            if (flag == null)
            {
                return Task.FromResult("Flag not found");
            }

            return Task.FromResult(flag);
        }

        /// <summary>
        /// Gets the phone code by the country short code asynchronously.
        /// </summary>
        /// <param name="countryCode">The country short code.</param>
        /// <returns>A string representing the phone code.</returns>
        public Task<string> GetPhoneCodeByCountryShortCodeAsync(string countryCode)
        {
            var phoneCode = _countryHelper.GetPhoneCodeByCountryShortCode(countryCode);
            if (phoneCode == null)
            {
                return Task.FromResult("Phone code not found");
            }

            return Task.FromResult(phoneCode);
        }

        /// <summary>
        /// Gets the regions by the country code asynchronously.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>A JSON string representing the regions.</returns>
        public Task<string> GetRegionsByCountryCodeAsync(string countryCode)
        {
            var regions = _countryHelper.GetRegionByCountryCode(countryCode);
            if (regions == null)
            {
                return Task.FromResult("No regions found");
            }

            return Task.FromResult(JsonConvert.SerializeObject(regions, Formatting.Indented));
        }

        /// <summary>
        /// Dispose of any resources being used.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether to dispose of managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

                }

                // Dispose unmanaged resources here.

                _disposed = true;
            }
        }
    }
}
