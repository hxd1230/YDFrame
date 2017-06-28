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
    public class SysIconController : Controller
    {
        //
        // GET: /Admin/SysIcon/
        [Dependency]
        public ISys_IconService _iconService { get; set; }
        public ActionResult Icons()
        {
            return View();
        }

        public class Tes
        {
            public int id { get; set; }
            public string text { get; set; }
        }
        public JsonResult GetIcons()
        {
            var roles = _iconService.LoadEntities(c => true).Select(c => new { id = c.Name, text = c.Name, iconCls = c.Name }).ToList();
            var recordCount = roles.Count;

            return Json(roles, JsonRequestBehavior.AllowGet);
        }
    }
}
