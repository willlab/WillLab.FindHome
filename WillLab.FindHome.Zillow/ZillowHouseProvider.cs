using System.Linq;
using System.Threading.Tasks;
using WillLab.FindHome.Core;
using WillLab.FindHome.Model;

namespace WillLab.FindHome.Zillow
{
    /// <summary>
    /// House search provider by using zillow api
    /// </summary>
    public class ZillowHouseProvider : IHouseProvider
    {
        public async Task<FindHouseResultModel> FindHouseAsync(string address, string city, string state, string zip)
        {
            FindHouseResultModel result = null;
            string cityStateZip =
                ((city == null) ? "" : city + "+") +
                ((state == null) ? "" : state + "+") +
                ((zip == null) ? "" : zip);

            var searchResult = await ZillowHelper.GetSearchResultsAsync(address, cityStateZip);
            if (searchResult != null)
            {
                if (searchResult.message != null)
                {
                    result = new FindHouseResultModel()
                    {
                        StatusCode = searchResult.message.code,
                        StatusMessage = searchResult.message.text
                    };

                    if (searchResult.message.code == ZillowEnvironment.StatusCode.ProcessOK &&
                        searchResult.response != null && searchResult.response.results != null &&
                        searchResult.response.results.Count() > 0)
                    {
                        result.HouseInfo = new HouseModel();
                        var property = searchResult.response.results[0];
                        result.HouseInfo.Address = property.address.street;
                        result.HouseInfo.City = property.address.city;
                        result.HouseInfo.State = property.address.state;
                        result.HouseInfo.Zipcode = property.address.zipcode;
                        result.HouseInfo.Latitude = property.address.latitude;
                        result.HouseInfo.Longitude = property.address.longitude;
                        if (property.zestimate != null && property.zestimate.amount != null)
                        {
                            result.HouseInfo.EstimatedValue = property.zestimate.amount.currency + " " + property.zestimate.amount.Value;
                        }
                        result.HouseInfo.Links.Add("Comparables", property.links.comparables);
                        result.HouseInfo.Links.Add("Details", property.links.homedetails);
                        result.HouseInfo.Links.Add("Map it", property.links.mapthishome);
                    }
                }
            }
            return result;
        }
    }
}
