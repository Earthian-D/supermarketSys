using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//主页控制器
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
        public ActionResult Product_category_add(string name,string id,string pId)
        {
            ViewBag.TypeName = name;
            ViewBag.TypeId = id;
            ViewBag.TypePid = pId;
            return View("~/Views/Home/product-category-add.cshtml");
        }
        public ActionResult Products_List()
        {
            return View("~/Views/Home/Products_List.cshtml");
        }
        public ActionResult homeindex()
        {
            return View("~/Views/Home/homeindex.cshtml");
        }
    }
}