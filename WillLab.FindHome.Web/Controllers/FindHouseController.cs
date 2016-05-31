using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WillLab.FindHome.Model;
using WillLab.FindHome.Service;
using WillLab.FindHome.Web.Models;

namespace WillLab.FindHome.Web.Controllers
{
    public class FindHouseController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Find a house details by address.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<ActionResult> Find(string address, string city, string state, string zipcode)
        {
            var model = new FindHouseViewModel();
            model.Address = address;
            model.City = city;
            model.State = state;
            model.Zipcode = zipcode;

            if (address != null && (city != null || state != null))
            {
                using (var service = new HouseService())
                {
                    model.HouseSearchResult = await service.FindHouseAsync(address, city, state, zipcode);
                }
            }
            return View("Find", model);
        }

        public async Task<ActionResult> SearchResult(string address, string city, string state, string zipcode)
        {
            var model = new FindHouseViewModel();
            model.Address = address;
            model.City = city;
            model.State = state;
            model.Zipcode = zipcode;

            if (address != null && (city != null || state != null))
            {
                using (var service = new HouseService())
                {
                    model.HouseSearchResult = await service.FindHouseAsync(address, city, state, zipcode);
                }
            }
            return PartialView("SearchResult", model);
        }
    }
}
