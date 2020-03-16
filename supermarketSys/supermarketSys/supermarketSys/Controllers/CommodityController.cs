using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//存放关于商品的相关页面的控制器
namespace supermarketSys.Controllers
{
    public class CommodityController : Controller
    {
        // GET: Commodity
        public ActionResult Commodity_Add()
        {
            return View("~/Views/Commodity/Commodity_Add.cshtml");
        }
    }
}