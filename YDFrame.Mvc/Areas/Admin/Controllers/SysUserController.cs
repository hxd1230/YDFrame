using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using YDFrame.Common;
using YDFrame.IBLL;
using YDFrame.Models;
using YDFrame.Mvc.Models;

namespace YDFrame.Mvc.Areas.Admin.Controllers
{
    public class SysUserController : Controller
    {
        [Dependency]
        public ISys_UserService _sysUserService { get; set; }
        [Dependency]
        public ISys_UserRoleService _sysUserRoleService { get; set; }
        [Dependency]
        public ISys_RoleService _sys_RoleService { get; set; }
        public ActionResult Users()
        {
            return View();
        }
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUsers()
        {
            List<UserRoleViewModel> users = _sysUserService.DbSession.ExecuteSelect<UserRoleViewModel>(@"select a.*,c.Name RoleName from Sys_User a,Sys_UserRole b,Sys_Role c
            where a.Id = b.UserId
            and b.RoleId = c.Id", new SqlParameter[] { });
            return Json(new { total = users.Count, rows = users.ToArray() }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddUser()
        {
            var sr = new StreamReader(Request.InputStream);
            var stream = sr.ReadToEnd();
            JObject jObject = (JObject)JsonConvert.DeserializeObject(stream);
            string userName = jObject["userName"].ToString();
            string nickName = jObject["nickName"].ToString();
            int roleId = Convert.ToInt32(jObject["roleId"]);
            string description = jObject["description"].ToString();
            Sys_User entity = new Sys_User
            {
                CreateTime = DateTime.Now,
                Description = description,
                IsLock = false,
                NickName = nickName,
                UserName = userName,
                PassWord = EncryptUtil.GetDefaultPwd()
            };
            _sysUserService.AddEntity(entity);
            int userId = _sysUserService.LoadEntities(c => true).Max(c => c.Id);
            if (_sysUserRoleService.AddEntity(new Sys_UserRole { RoleId = roleId, UserId = userId }) != null)
            {
                return Json(new { state = 200, message = "ok" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { state = 201, message = "no" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteUser()
        {
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}
