using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YDFrame.IBLL;
using YDFrame.Models;
using YDFrame.Mvc.Areas.Admin.Models;

namespace YDFrame.Mvc.Areas.Admin.Controllers
{
    public class WX_TypeController : Controller
    {
        [Dependency]
        public IWX_TypeService _typeService { get; set; }
        public ActionResult Accounts()
        {
            return View();
        }
        public JsonResult GetTypes()
        {
            Notify<WX_Type> notify = new Notify<WX_Type>();
            List<WX_Type> types = _typeService.LoadEntities(c => true).OrderByDescending(c => c.Name).ToList();
            return Json(types.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}
