using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YDFrame.Models;

namespace YDFrame.Mvc.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["YD_USER"] == null)
            {
                return Redirect("~/Admin/AccountInfo/Login");
            }
            string user = ((Sys_User)Session["YD_USER"]).UserName;
            ViewBag.User = user;
            return View();
        }
    }
}
