using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace supermarketSys.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View("~/Views/Home/Home.cshtml");
        }
        public ActionResult Category_Manage()
        {
            return View("~/Views/Home/Category_Manage.cshtml");
        }
        public ActionResult product_category_add()
        {
            return View("~/Views/Home/product-category-add.cshtml");
        }
    }
}