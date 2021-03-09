using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amazon_WebApp.Areas.Inventory.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory/Inventory
        public ActionResult Index()
        {
            return View();
        }
    }
}