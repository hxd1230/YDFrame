using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YDFrame.IBLL;
using YDFrame.Models;
using YDFrame.Common.Extensions;
using YDFrame.Mvc.Areas.Admin.Models;
namespace YDFrame.Mvc.Areas.Admin.Controllers
{
    public class SysRoleController : Controller
    {
        #region IOC,DI
        [Dependency]
        public ISys_RoleService _sysRoleService { get; set; }
        [Dependency]
        public ISys_RoleMenuService _sysRoleMenuService { get; set; }
        #endregion
        [HttpGet]
        public ActionResult Roles()
        {
            return View();
        }
        public JsonResult GetRoles()
        {
            var roles = _sysRoleService.LoadEntities(c => true).ToList();
            var recordCount = roles.Count;
            return Json(new { total = recordCount, rows = roles.ToArray() }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 给角色分配菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult RoleMenu()
        {
            string roleId = Request["roleId"];
            int id = roleId.ToInt32();
            string menuIds = Request["menuIds"];
            #region 分配之前先删除
            List<Sys_RoleMenu> roleMenus = _sysRoleMenuService.LoadEntities(c => c.RoleId == id).ToList();

            for (int i = 0; i < roleMenus.Count; i++)
            {
                Sys_RoleMenu entity = new Sys_RoleMenu { Id = roleMenus[i].Id, RoleId = roleMenus[i].RoleId, MenuId = roleMenus[i].MenuId };
                _sysRoleMenuService.DeleteEntity(entity);
            }
            #endregion
            if (menuIds.Contains(","))
            {
                string[] arrays = menuIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arrays.Length; i++)
                {

                    _sysRoleMenuService.AddEntity(new Sys_RoleMenu { MenuId = arrays[i].ToInt32(), RoleId = roleId.ToInt32() });
                }
            }
            return Json(new { state = 200 }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadRoleMenu(string roleId)
        {
            int id = roleId.ToInt32();
            List<Sys_RoleMenu> roleMenus = _sysRoleMenuService.LoadEntities(c => c.RoleId == id).ToList();
            return Json(roleMenus, JsonRequestBehavior.AllowGet);
        }
        #region 新增角色
        public JsonResult AddRole()
        {
            string state = Request["state"];

            Sys_Role entity = new Sys_Role { Description = Request["description"], Name = Request["name"], State = state == "1" ? 1 : 0 };

            if (_sysRoleService.AddEntity(entity) != null)
            {
                return Json(new { state = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { state = 201 }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 删除角色
        public JsonResult DeleteRole(int roleId)
        {
            bool flag = _sysRoleService.DeleteEntity(new Sys_Role { Id = roleId });
            Notify<bool> result = new Notify<bool>
            {
                Data = flag
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新角色
        [HttpGet]
        public JsonResult UpdateRole()
        {
            int roleId = Request["roleId"].ToInt32();
            Sys_Role role = _sysRoleService.LoadEntities(c => c.Id == roleId).SingleOrDefault();
            Notify<Sys_Role> result = new Notify<Sys_Role>
            {
                Data = role
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateRole(int roleId)
        {
            Sys_Role role = _sysRoleService.LoadEntities(c => c.Id == roleId).SingleOrDefault();
            Notify<Sys_Role> result = new Notify<Sys_Role>
            {
                Data = role
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
