using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace supermarketSys.Controllers
{
    public class OrderformController : Controller
    {
        // GET: Orderform
        public ActionResult Orderform()
        {
            return View("~/Views/Orderform/Orderform.cshtml");
        }
    }
}