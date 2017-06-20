 

using YDFrame.IBLL;
using YDFrame.IDAL;
using YDFrame.Models;
using YDFrame.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace YDFrame.BLL
{
	
	public partial class Sys_LoginLogService :BaseService<Sys_LoginLog>,ISys_LoginLogService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = new Sys_LoginLogRepository();
        }
    }   
	
	public partial class Sys_MenuService :BaseService<Sys_Menu>,ISys_MenuService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = new Sys_MenuRepository();
        }
    }   
	
	public partial class Sys_RoleService :BaseService<Sys_Role>,ISys_RoleService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = new Sys_RoleRepository();
        }
    }   
	
	public partial class Sys_RoleMenuService :BaseService<Sys_RoleMenu>,ISys_RoleMenuService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = new Sys_RoleMenuRepository();
        }
    }   
	
	public partial class Sys_UserService :BaseService<Sys_User>,ISys_UserService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = new Sys_UserRepository();
        }
    }   
	
	public partial class Sys_UserRoleService :BaseService<Sys_UserRole>,ISys_UserRoleService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = new Sys_UserRoleRepository();
        }
    }   
	
	public partial class WX_AccountService :BaseService<WX_Account>,IWX_AccountService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = new WX_AccountRepository();
        }
    }   
	
	public partial class WX_TypeService :BaseService<WX_Type>,IWX_TypeService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = new WX_TypeRepository();
        }
    }   
	
	public partial class YD_ArticleService :BaseService<YD_Article>,IYD_ArticleService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = new YD_ArticleRepository();
        }
    }   
	
}