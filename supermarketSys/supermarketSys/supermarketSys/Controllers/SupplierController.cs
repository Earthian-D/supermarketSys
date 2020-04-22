using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//供应商
namespace supermarketSys.Controllers
{
    public class SupplierController : Controller
    {

        public ActionResult Supplier_Add()
        {
            return View("~/Views/Supplier/Supplier_Add.cshtml");
        }
    }
}