using CountryData.Standard;
using CountryDataDotnetDemo.API.Services;
using Moq;
using Newtonsoft.Json;

namespace CountryDataDotnetDemo.Tests
{

    public class CountryDataDotnetDemoTests
    {
        private Mock<> _mockCountryHelper;
        private CountryDataServices _countryDataServices;

        public CountryDataDotnetDemoTests()
        {
            _mockCountryHelper = new Mock<CountryHelper>();
            _countryDataServices = new CountryDataServices(_mockCountryHelper.Object);
        }

        [Fact]
        public async Task GetCountriesAsync_ShouldReturnCountries()
        {
            // arrange
            var countries = new List<string> { "Ghana" };
            _mockCountryHelper.Setup(ch => ch.GetCountries()).Returns(countries);

            // act
            var result = await _countryDataServices.GetCountriesAsync();

            // assert
            var expected = JsonConvert.SerializeObject(countries, Formatting.Indented);

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetCountryByCodeAsync_ShouldReturnCountry()
        {
            var country = new Country { CountryName = "Ghana" };
            _mockCountryHelper.Setup(ch => ch.GetCountryByCode("GH")).Returns(country);

            // act
            var result = await _countryDataServices.GetCountryByCodeAsync("GH");

            //assert

            Assert.Equal(JsonConvert.SerializeObject(country, Formatting.Indented), result);

        }

    }
}