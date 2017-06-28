using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YDFrame.BLL;
using YDFrame.DAL;
using YDFrame.IBLL;
using YDFrame.IDAL;

namespace YDFrame.Mvc
{
    public class DependencyRegisterType
    {
        //系统注入
        public static void Container_Sys(ref UnityContainer container)
        {
            container.RegisterType<ISys_MenuRepository, Sys_MenuRepository>();
            container.RegisterType<ISys_MenuService, Sys_MenuService>();

            container.RegisterType<ISys_UserRepository, Sys_UserRepository>();
            container.RegisterType<ISys_UserService, Sys_UserService>();

            container.RegisterType<ISys_RoleRepository, Sys_RoleRepository>();
            container.RegisterType<ISys_RoleService, Sys_RoleService>();

            container.RegisterType<ISys_RoleMenuRepository, Sys_RoleMenuRepository>();
            container.RegisterType<ISys_RoleMenuService, Sys_RoleMenuService>();

            container.RegisterType<ISys_UserRoleRepository, Sys_UserRoleRepository>();
            container.RegisterType<ISys_UserRoleService, Sys_UserRoleService>();

            container.RegisterType<IYD_ArticleRepository, YD_ArticleRepository>();
            container.RegisterType<IYD_ArticleService, YD_ArticleService>();

            container.RegisterType<IWX_AccountRepository, WX_AccountRepository>();
            container.RegisterType<IWX_AccountService, WX_AccountService>();

            container.RegisterType<IWX_TypeRepository, WX_TypeRepository>();
            container.RegisterType<IWX_TypeService, WX_TypeService>();

            container.RegisterType<ISys_ErrorRepository, Sys_ErrorRepository>();
            container.RegisterType<ISys_ErrorService, Sys_ErrorService>();

            container.RegisterType<ISys_LogRepository, Sys_LogRepository>();
            container.RegisterType<ISys_LogService, Sys_LogService>();

            container.RegisterType<ISys_IconRepository, Sys_IconRepository>();
            container.RegisterType<ISys_IconService, Sys_IconService>();
        }
    }
}