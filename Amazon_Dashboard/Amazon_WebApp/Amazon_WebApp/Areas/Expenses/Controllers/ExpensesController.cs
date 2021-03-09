using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amazon_WebApp.Areas.Expenses.Controllers
{
    public class ExpensesController : Controller
    {
        // GET: Expenses/Expenses
        public ActionResult Index()
        {
            return View();
        }
    }
}