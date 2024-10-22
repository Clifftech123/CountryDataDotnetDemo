namespace CountryDataDotnetDemo.Web.Components.Models
{
    public class ICountryDataApiModles
    {
        public class Country
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }

        public class PaginatedCountryData
        {
            public int TotalCount { get; set; }
            public List<Country> Countries { get; set; }
        }

        public class Region
        {
            public string Name { get; set; }
        }

        public class Flag
        {
            public string Url { get; set; }
        }

        public class PhoneCode
        {
            public string Code { get; set; }
        }


    }
}
