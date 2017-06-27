using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YDFrame.Common;
using YDFrame.IBLL;
using YDFrame.Models;
using YDFrame.Mvc.Areas.Admin.Models;

namespace YDFrame.Mvc.Areas.Admin.Controllers
{
    public class AccountInfoController : Controller
    {
        [Dependency]
        public ISys_UserService _sysUserService { get; set; }
        [Dependency]
        public ISys_LogService _logService { get; set; }
        public ActionResult Login()
        {
            if (Session["YD_USER"] != null)
            {
                string user = Session["YD_USER"].ToString();
                if (_sysUserService.LoadEntities(c => c.UserName.Equals(user)).SingleOrDefault() != null)
                {
                    return Redirect("~/Admin/Home/Index");
                }
            }
            return View();
        }
        [HttpPost]
        public JsonResult Login(Sys_User entity)
        {
            try
            {
                int a = 10;
                int b = 0;
                int c = a / b;
            }
            catch (Exception ex)
            {
                NLogUtil.Error(ex.ToString());
                //throw;
            }
            Sys_User user = _sysUserService.LoadEntities(c => c.UserName.Equals(entity.UserName)).SingleOrDefault();
            if (user == null)
            {
                return Json(new { state = 201, message = "用户名或密码错误" }, JsonRequestBehavior.AllowGet);
            }
            if (user.PassWord.Equals(EncryptUtil.Md5(entity.PassWord)))
            {
                Session["YD_USER"] = user;
                string ip = Request.UserHostAddress;
                Sys_Log log = _logService.AddEntity(new Sys_Log { OccurTime = DateTime.Now, UserId = user.Id, Type = 1, LoginIp = ip });
                return Json(new { state = 200, messgae = "登录成功" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { state = 201, message = "用户名或密码错误" }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult LogOff()
        {
            Sys_User user = (Sys_User)Session["YD_USER"];
            _logService.AddEntity(new Sys_Log { OccurTime = DateTime.Now, LoginIp = Request.UserHostAddress, Type = 2, UserId = user.Id });
            Notify<bool> notify = new Notify<bool>();
            Session.Clear();
            Session.Abandon();
            notify.Data = true;
            return Json(notify, JsonRequestBehavior.AllowGet);
        }
    }
}
