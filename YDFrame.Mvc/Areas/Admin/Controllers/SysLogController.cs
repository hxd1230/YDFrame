using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YDFrame.IBLL;

namespace YDFrame.Mvc.Areas.Admin.Controllers
{
    public class SysLogController : Controller
    {
        //
        // GET: /Admin/SysLog/

        [Dependency]
        public ISys_LogService _logService { get; set; }
        public ActionResult Logs()
        {
            return View();
        }
        public JsonResult GetLogs()
        {
            var logs = _logService.LoadEntities(c => true).ToList();
            var recordCount = logs.Count;
            return Json(new { total = recordCount, rows = logs.ToArray() }, JsonRequestBehavior.AllowGet);
        }

    }
}
