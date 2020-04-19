using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace supermarketSys.Controllers
{
    public class SellingController : Controller
    {
        // GET: Selling
        public ActionResult Salesorder()
        {
            return View("~/Views/Selling/Salesorder.cshtml");
        }
        public ActionResult SalesorderList()
        {
            return View("~/Views/Selling/SalesorderList.cshtml");
        }
    }
}