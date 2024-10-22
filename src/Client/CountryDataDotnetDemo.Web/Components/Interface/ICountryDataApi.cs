using Refit;

namespace CountryDataDotnetDemo.Web.Components.Interface
{
    public interface ICountryDataApi
    {
        [Get("/api/countrydata/countries")]
        Task<string> GetCountriesAsync();

        [Get("/api/countrydata/country/{code}")]
        Task<string> GetCountryByCodeAsync(string code);

        [Get("/api/countrydata/countrydata")]
        Task<string> GetCountryDataAsync([Query] int offset = 1, [Query] int limit = 5, [Query] string? searchQuery = null);

        [Get("/api/countrydata/regions/{countryCode}")]
        Task<string> GetRegionsByCountryCodeAsync(string countryCode);

        [Get("/api/countrydata/flag/{countryCode}")]
        Task<string> GetCountryFlagAsync(string countryCode);

        [Get("/api/countrydata/phonecode/{countryCode}")]
        Task<string> GetPhoneCodeByCountryShortCodeAsync(string countryCode);

        [Get("/api/countrydata/countrybyphonecode/{phoneCode}")]
        Task<string> GetCountryByPhoneCodeAsync(string phoneCode);
    }
}
