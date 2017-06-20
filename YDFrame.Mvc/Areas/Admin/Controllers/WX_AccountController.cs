using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YDFrame.IBLL;
using YDFrame.Models;
using YDFrame.Mvc.Areas.Admin.Models;
using YDFrame.Common.Extensions;
namespace YDFrame.Mvc.Areas.Admin.Controllers
{
    public class WX_AccountController : Controller
    {
        [Dependency]
        public IWX_AccountService _wxaccountService { get; set; }
        public ActionResult Accounts()
        {
            return View();
        }
        public JsonResult GetAccounts()
        {
            Notify<WX_Account> notify = new Notify<WX_Account>();
            List<WX_Account> accounts = _wxaccountService.LoadEntities(c => true).OrderByDescending(c => c.IsDefault).ToList();
            return Json(new { rows = accounts.ToArray(), total = accounts.Count }, JsonRequestBehavior.AllowGet);
        }
        #region 新增公众号
        [HttpPost]
        public JsonResult AddAccount(WX_Account entity)
        {
            string enable = Request["Enable"];
            string isDefault = Request["IsDefault"];
            entity.CreateTime = DateTime.Now;
            entity.Enable = enable.ToInt32() == 0 ? true : false;
            entity.IsDefault = isDefault.ToInt32() == 0 ? true : false;
            Notify<bool> notify = new Notify<bool>();
            if (null != _wxaccountService.AddEntity(entity))
            {
                notify.Data = true;
            }
            else
            {
                notify.Data = false;
                notify.Status = StatusCode.Error;
                notify.Message = "删除失败";
            }
            return Json(notify, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除公众号
        [HttpPost]
        public JsonResult DeleteAccount(int id)
        {
            int Id = Request["Id"].ToInt32();
            Notify<bool> notify = new Notify<bool>();
            WX_Account entity = new WX_Account { Id = Id };
            if (_wxaccountService.DeleteEntity(entity))
            {
                notify.Data = true;
            }
            else
            {
                notify.Data = false;
                notify.Status = StatusCode.Error;
                notify.Message = "删除失败";
            }
            return Json(notify, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改公众号
        public JsonResult UpdateAccount(WX_Account entity)
        {
            string enable = Request["Enable"];
            string isDefault = Request["IsDefault"];
            entity.CreateTime = DateTime.Now;
            entity.Enable = enable.ToInt32() == 0 ? true : false;
            entity.IsDefault = isDefault.ToInt32() == 0 ? true : false;
            entity.Id = Request["Id"].ToInt32();
            Notify<bool> notify = new Notify<bool>();
            if (_wxaccountService.UpdateEntity(entity))
            {
                notify.Data = true;
            }
            else
            {
                notify.Data = false;
                notify.Status = StatusCode.Error;
                notify.Message = "删除失败";
            }
            return Json(notify, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
