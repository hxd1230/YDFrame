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
            Sys_User user = _sysUserService.LoadEntities(c => c.UserName.Equals(entity.UserName)).SingleOrDefault();
            if (user == null)
            {
                return Json(new { state = 201, message = "用户名或密码错误" }, JsonRequestBehavior.AllowGet);
            }
            if (user.PassWord.Equals(EncryptUtil.Md5(entity.PassWord)))
            {
                Session["YD_USER"] = user;
                return Json(new { state = 200, messgae = "登录成功" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { state = 201, message = "用户名或密码错误" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LogOff()
        {
            Notify<bool> notify = new Notify<bool>();
            Session.Clear();
            Session.Abandon();
            notify.Data = true;
            return Json(notify, JsonRequestBehavior.AllowGet);
        }
    }
}
