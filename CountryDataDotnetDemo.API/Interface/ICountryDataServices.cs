namespace CountryDataDotnetDemo.API.Interface
{
    public interface ICountryDataServices
    {
        Task<string> GetCountriesAsync();
        Task<string> GetCountryByCodeAsync(string code);
        Task<string> GetCountryDataAsync();
        Task<string> GetRegionsByCountryCodeAsync(string countryCode);
        Task<string> GetCountryFlagAsync(string countryCode);
        Task<string> GetPhoneCodeByCountryShortCodeAsync(string countryCode);
        Task<string> GetCountryByPhoneCodeAsync(string phoneCode);
    }
}