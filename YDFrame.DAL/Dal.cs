 

using YDFrame.IDAL;
using YDFrame.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YDFrame.DAL
{
		
	public partial class Sys_LoginLogRepository :BaseRepository<Sys_LoginLog>,ISys_LoginLogRepository
    {

    }
		
	public partial class Sys_MenuRepository :BaseRepository<Sys_Menu>,ISys_MenuRepository
    {

    }
		
	public partial class Sys_RoleRepository :BaseRepository<Sys_Role>,ISys_RoleRepository
    {

    }
		
	public partial class Sys_RoleMenuRepository :BaseRepository<Sys_RoleMenu>,ISys_RoleMenuRepository
    {

    }
		
	public partial class Sys_UserRepository :BaseRepository<Sys_User>,ISys_UserRepository
    {

    }
		
	public partial class Sys_UserRoleRepository :BaseRepository<Sys_UserRole>,ISys_UserRoleRepository
    {

    }
		
	public partial class WX_AccountRepository :BaseRepository<WX_Account>,IWX_AccountRepository
    {

    }
		
	public partial class WX_TypeRepository :BaseRepository<WX_Type>,IWX_TypeRepository
    {

    }
		
	public partial class YD_ArticleRepository :BaseRepository<YD_Article>,IYD_ArticleRepository
    {

    }
	
}