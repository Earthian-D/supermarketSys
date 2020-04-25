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
        public static string empcode;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home(string code)
        {
            empcode = code;
            ViewBag.empcode = code;
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
        public ActionResult HomeWeb(string code)
        {
            empcode = code;
            ViewBag.empcode = code;
            return View("~/Views/Home/HomeWeb.cshtml");
        }
        public ActionResult Checkingin()
        {
            ViewBag.empcode = empcode;
            return View("~/Views/Checkingin/Checkin.cshtml");
        }
        //供应商
        public ActionResult Supplier()
        {
            return View("~/Views/Home/Supplier.cshtml");
        }

        //用户
        public ActionResult Users()
        {
            return View("~/Views/Home/Users.cshtml");
        }
        //用户
        public ActionResult Staff()
        {
            return View("~/Views/Home/Staff.cshtml");
        }

    }
}