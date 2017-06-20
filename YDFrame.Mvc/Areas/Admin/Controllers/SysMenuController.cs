using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YDFrame.IBLL;
using YDFrame.Models;
using YDFrame.Mvc.Models;
using YDFrame.Common.Extensions;
using YDFrame.Mvc.Areas.Admin.Models;
namespace YDFrame.Mvc.Areas.Admin.Controllers
{
    public class SysMenuController : Controller
    {
        [Dependency]
        public ISys_MenuService _sysMenuService { get; set; }
        [Dependency]
        public ISys_RoleMenuService _sysRoleMenuService { get; set; }
        [Dependency]
        public ISys_UserRoleService _sysUserRoleService { get; set; }
        public JsonResult GetMenu(string userName)
        {
            List<ParentMenu> menus = new List<ParentMenu>();
            List<Sys_Menu> all = _sysMenuService.GetMenuByUserName(userName);
            List<Sys_Menu> pMenus = all.Where(c => c.ParentId == 0).ToList();
            foreach (var item in pMenus)
            {
                menus.Add(new ParentMenu
                {
                    text = item.Name,
                    id = item.Id,
                    children = GetSubNode(item.Id, all)
                });
            }
            return Json(menus.ToArray(), JsonRequestBehavior.AllowGet);
        }
        private List<ChildrenMenu> GetSubNode(int parentId, List<Sys_Menu> menus)
        {
            List<ChildrenMenu> cMenus = new List<ChildrenMenu>();
            List<Sys_Menu> pMenus = menus.Where(c => c.ParentId == parentId).ToList();
            foreach (var item in pMenus)
            {
                cMenus.Add(new ChildrenMenu
                {
                    url = item.Url,
                    text = "<a onclick='fun(this);' url='" + item.Url + "' href='javascript:;'>" + item.Name + "</a>"
                });
            }
            return cMenus;
        }
        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Menus()
        {
            return View();
        }

        /// <summary>
        /// 分配权限加载菜单
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public JsonResult LoadMenu(string userName)
        {
            List<PowerParentMenu> menus = new List<PowerParentMenu>();
            List<Sys_Menu> all = _sysMenuService.GetMenuByUserName(userName);
            List<Sys_Menu> pMenus = all.Where(c => c.ParentId == 0).ToList();
            foreach (var item in pMenus)
            {
                menus.Add(new PowerParentMenu
                {
                    icon = item.Icon,
                    desc = item.Description,
                    text = item.Name,
                    id = item.Id,
                    children = LoadSubNode(item.Id, all)
                });
            }
            return Json(menus.ToArray(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 分配权限加载子菜单
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="menus"></param>
        /// <returns></returns>
        private List<PowerChildrenMenu> LoadSubNode(int parentId, List<Sys_Menu> menus)
        {
            List<PowerChildrenMenu> cMenus = new List<PowerChildrenMenu>();
            List<Sys_Menu> pMenus = menus.Where(c => c.ParentId == parentId).ToList();
            foreach (var item in pMenus)
            {
                cMenus.Add(new PowerChildrenMenu
                {
                    icon = item.Icon,
                    desc = item.Description,
                    url = item.Url,
                    text = item.Name,
                    id = item.Id
                });
            }
            return cMenus;
        }



        public JsonResult GetMenus(string userName)
        {
            List<ParentMenu> menus = new List<ParentMenu>();
            List<Sys_Menu> all = _sysMenuService.GetMenuByUserName(userName);
            List<Sys_Menu> pMenus = all.Where(c => c.ParentId == 0).ToList();
            foreach (var item in pMenus)
            {
                menus.Add(new ParentMenu
                {
                    text = item.Name,
                    id = item.Id,
                    children = GetSubNode(item.Id, all)
                });
            }
            return Json(new { total = menus.Count, rows = menus.ToArray() }, JsonRequestBehavior.AllowGet);
        }

        #region 新增菜单
        [HttpPost]
        public JsonResult AddMenu()
        {
            Notify<bool> notify = new Notify<bool>();
            Sys_Menu entity = new Sys_Menu
            {
                Description = Request["txtDesc"],
                Name = Request["txtName"],
                Url = Request["txtUrl"],
                ParentId = Request["txtParentId"].ToInt32(),
                IsHide = Request["isHide"].ToInt32() == 1 ? true : false
            };
            if (null != _sysMenuService.AddEntity(entity))
            {
                int maxMenuId = _sysMenuService.LoadEntities(c => true).Max(c => c.Id);

                #region 查询出当前登录角色,给角色授权菜单
                Sys_User user = (Sys_User)Session["YD_USER"];
                int roleId = (int)_sysUserRoleService.LoadEntities(c => c.UserId == user.Id).SingleOrDefault().RoleId;
                #endregion
                _sysRoleMenuService.AddEntity(new Sys_RoleMenu { RoleId = roleId, MenuId = maxMenuId });
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

        #region 删除菜单
        [HttpPost]
        public JsonResult DeleteMenu()
        {
            int menuId = Request["menuId"].ToInt32();
            Notify<bool> notify = new Notify<bool>();
            Sys_Menu entity = new Sys_Menu { Id = menuId };
            if (_sysMenuService.DeleteEntity(entity))
            {
                int id = _sysRoleMenuService.LoadEntities(c => c.MenuId == menuId).SingleOrDefault().Id;
                _sysRoleMenuService.DeleteEntity(new Sys_RoleMenu { Id = id });
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

        #region 修改菜单
        public JsonResult UpdateMenu()
        {
            Sys_Menu entity = new Sys_Menu
            {
                Id = Request["menuId"].ToInt32(),
                Description = Request["txtDesc"],
                Name = Request["txtName"],
                Url = Request["txtUrl"],
                IsHide = Request["isHide"].ToBoolean(),
                ParentId = Convert.ToInt32(Request["txtParentId"])
            };
            Notify<bool> notify = new Notify<bool>();
            if (_sysMenuService.UpdateEntity(entity))
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
