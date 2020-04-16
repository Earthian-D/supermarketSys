using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace supermarketSys.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View("~/Views/Inventory/Inventory.cshtml");
        }
        public ActionResult Inventory()
        {
            return View("~/Views/Inventory/InventoryDetail.cshtml");
        }
    }
}