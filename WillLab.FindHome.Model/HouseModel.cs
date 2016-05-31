using System.Collections.Generic;

namespace WillLab.FindHome.Model
{
    /// <summary>
    /// House info data model
    /// </summary>
    public class HouseModel
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string EstimatedValue { get; set; }
        public Dictionary<string, string> Links { get; set; }

        public HouseModel()
        {
            Links = new Dictionary<string, string>();
        }
    }
}
