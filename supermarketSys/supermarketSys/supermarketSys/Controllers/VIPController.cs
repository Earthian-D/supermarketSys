using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace supermarketSys.Controllers
{
    public class VIPController : Controller
    {
        // GET: VIP
        public ActionResult Index()
        {
            return View("~/Views/VIP/user_list.cshtml");
        }
        public ActionResult MemberLevel()
        {
            return View("~/Views/VIP/member_level.cshtml");
        }
    }
}