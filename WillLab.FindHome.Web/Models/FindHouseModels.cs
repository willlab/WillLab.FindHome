using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WillLab.FindHome.Model;

namespace WillLab.FindHome.Web.Models
{
    public class FindHouseViewModel
    {
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string Zipcode { get; set; }

        public List<string> States { get; set; }

        public FindHouseResultModel HouseSearchResult { get; set; }

        public FindHouseViewModel()
        {
            States = new List<string>()
            {
                "Alaska", "Alabama", "Arizona", "Arkansas",
                "California", "Colorado", "Connecticut",
                "Delaware", "District Of Columbia", "Florida",
                "Georgia", "Hawaii", "Idaho", "Illinois",
                "Indiana", "Iowa", "Kansas", "Kentucky",
                "Louisiana", "Maine", "Maryland",
                "Massachusetts", "Michigan", "Minnesota",
                "Mississippi", "Missouri", "Montana",
                "Nebraska", "Nevada", "New Hampshire",
                "New Jersey", "New Mexico", "New York",
                "North Carolina", "North Dakota", "Ohio",
                "Oklahoma", "Oregon", "Pennsylvania",
                "Rhode Island", "South Carolina", "South Dakota",
                "Tennessee", "Texas", "Utah", "Vermont",
                "Virginia", "Washington", "West Virginia",
                "Wisconsin", "Wyoming"};
        }
    }
}