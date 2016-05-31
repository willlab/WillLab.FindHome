using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using WillLab.FindHome.Zillow.Models;

namespace WillLab.FindHome.Zillow
{
    public class ZillowHelper
    {
        public static async Task<searchresults> GetSearchResultsAsync(string address, string cityStateZip)
        {
            searchresults result = null;
            try
            {
                // call Zillow API
                result = await WSRequestAsync<searchresults>(
                    ZillowEnvironment.Url.SearchResults,
                    new Dictionary<string, string>
                    {
                        { ZillowEnvironment.APIParameter.Identifier, ZillowEnvironment.APIKey},
                        { ZillowEnvironment.APIParameter.Address, address},
                        { ZillowEnvironment.APIParameter.CityStateZip, cityStateZip}
                    });
            }
            catch (Exception ex)
            {
                // create an error response
                result = new searchresults();
                result.message = new Message()
                {
                    code = ZillowEnvironment.StatusCode.ServerSideError,
                    text = ex.Message
                };
            }

            return result;
        }

        #region Private Functions
        /// <summary>
        /// Zillow Web API request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static async Task<T> WSRequestAsync<T>(string url, Dictionary<string, string> parameters)
        {
            T result = default(T);
            using (var client = new HttpClient())
            {
                var u = new UriBuilder(url);
                u.Query = string.Join("&",
                    parameters.Select(kvp => string.Format("{0}={1}",
                    HttpUtility.UrlEncode(kvp.Key), HttpUtility.UrlEncode(kvp.Value))));

                var xmlResponse = await client.GetStringAsync(u.Uri);
                using (var reader = new StringReader(xmlResponse))
                {
                    result = (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                }
            }

            return result;
        }
        #endregion
    }
}
