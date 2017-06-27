using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YDFrame.IBLL;

namespace YDFrame.Mvc.Areas.Admin.Controllers
{
    public class SysErrorController : Controller
    {
        //
        // GET: /Admin/SysError/
        [Dependency]
        public ISys_ErrorService _errorService { get; set; }
        public ActionResult Errors()
        {
            return View();
        }
        public JsonResult GetErrors()
        {
            var roles = _errorService.LoadEntities(c => true).ToList();
            var recordCount = roles.Count;
            return Json(new { total = recordCount, rows = roles.ToArray() }, JsonRequestBehavior.AllowGet);
        }
    }
}
