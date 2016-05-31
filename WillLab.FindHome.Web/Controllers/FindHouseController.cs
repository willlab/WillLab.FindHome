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

        public ActionResult Find()
        {
            return View("Find", new FindHouseViewModel());
        }


        public async Task<ActionResult> SearchResult(FindHouseViewModel model)
        {
            if (model.Address != null && (model.City != null || model.State != null))
            {
                using (var service = new HouseService())
                {
                    model.HouseSearchResult = await service.FindHouseAsync(model.Address, model.City, model.State, model.Zipcode);
                }
            }
            return PartialView("SearchResult", model);
        }

    }
}
