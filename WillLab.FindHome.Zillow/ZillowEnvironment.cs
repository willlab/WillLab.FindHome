using System.Configuration;

namespace WillLab.FindHome.Zillow
{
    class ZillowEnvironment
    {
        /// <summary>
        /// Zillow web service api key
        /// </summary>
        public static readonly string APIKey = ConfigurationManager.AppSettings["Zillow:APIKey"];

        /// <summary>
        /// Zillow web service urls
        /// </summary>
        public static class Url
        {
            // Home Valuation
            public const string SearchResults = "http://www.zillow.com/webservice/GetSearchResults.htm";
            public const string ZEstimate = "http://www.zillow.com/webservice/GetZestimate.htm";
            public const string Chart = "http://www.zillow.com/webservice/GetChart.htm";
            public const string Comps = "http://www.zillow.com/webservice/GetComps.htm";

            // Neighboorhood Information
            public const string DemoGraphics = "http://www.zillow.com/webservice/GetDemographics.htm";
            public const string RegionChildren = "http://www.zillow.com/webservice/GetRegionChildren.htm";
            public const string RegionChart = "http://www.zillow.com/webservice/GetRegionChart.htm";

            // Property Details
            public const string DeepSearchResults = "http://www.zillow.com/webservice/GetDeepSearchResults.htm";
            public const string DeepComps = "http://www.zillow.com/webservice/GetDeepComps.htm";
            public const string UpdatedPropertyDetails = "http://www.zillow.com/webservice/GetUpdatedPropertyDetails.htm";

            // Mortgage
            public const string RateSummary = "http://www.zillow.com/webservice/GetRateSummary.htm";
            public const string MonthlyPayments = "http://www.zillow.com/webservice/GetMonthlyPayments.htm";
        }

        /// <summary>
        /// Zillow web service parameter keywords
        /// </summary>
        public static class APIParameter
        {
            public const string Identifier = "zws-id";
            public const string PropertyId = "zpid";
            public const string Address = "address";
            public const string CityStateZip = "citystatezip";
            public const string ReturnRentZestimate = "rentzestimate";
            public const string ChartUnitType = "unit-type";
            public const string ChartImageWideth = "width";
            public const string ChartImageLength = "length";
            public const string ChartDuration = "chartDuration";
            public const string CompCount = "count";
        }

        /// <summary>
        /// Zillow search result status code
        /// </summary>
        public static class StatusCode
        {
            public const string ProcessOK = "0";
            public const string ServerSideError = "1";
            public const string InvalidZWSID = "2";
            public const string WebServiceUnavailable = "3";
            public const string APIUnavailable = "4";
            public const string InvalidAddress = "500";
            public const string InvalidCityStateZip = "501";
            public const string NoResultFound = "502";
            public const string FailedResolveCityStateZip = "503";
            public const string AreaNotCovered = "504";
            public const string RequestTimeout = "505";
            public const string AddressTooLong = "506";
            public const string NotExactMatchFound = "507"; 
        }
    }
}
