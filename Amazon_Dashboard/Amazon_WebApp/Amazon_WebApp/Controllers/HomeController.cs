using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmazonModel.Inventory;

namespace Amazon_WebApp.Controllers
{
    public class HomeController : Controller
    {
        InventoryEntities db = new InventoryEntities(); 
        public ActionResult Index()
        {
            var startDate = new DateTime(2020, 01, 01);
            var endDate = new DateTime(2021, 12, 31);
            var mapSales = db.UdfGetOrderMapBySales(startDate, endDate)
                .ToArray();
            return View(mapSales);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}