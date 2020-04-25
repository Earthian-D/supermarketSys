using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//用户
namespace supermarketSys.Controllers
{
    public class UsersController : Controller
    {

        public ActionResult Users_Add()
        {//添加权限
            return View("~/Views/Users/Users_Add.cshtml");
        }
        public ActionResult Staff_Add()
        {//添加员工
            return View("~/Views/Users/Staff_Add.cshtml");
        }
    }
}