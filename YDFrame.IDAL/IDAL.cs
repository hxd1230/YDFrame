 
using YDFrame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YDFrame.IDAL
{
   
	
	public partial interface ISys_LoginLogRepository :IBaseRepository<Sys_LoginLog>
    {
      
    }
	
	public partial interface ISys_MenuRepository :IBaseRepository<Sys_Menu>
    {
      
    }
	
	public partial interface ISys_RoleRepository :IBaseRepository<Sys_Role>
    {
      
    }
	
	public partial interface ISys_RoleMenuRepository :IBaseRepository<Sys_RoleMenu>
    {
      
    }
	
	public partial interface ISys_UserRepository :IBaseRepository<Sys_User>
    {
      
    }
	
	public partial interface ISys_UserRoleRepository :IBaseRepository<Sys_UserRole>
    {
      
    }
	
	public partial interface IWX_AccountRepository :IBaseRepository<WX_Account>
    {
      
    }
	
	public partial interface IWX_TypeRepository :IBaseRepository<WX_Type>
    {
      
    }
	
	public partial interface IYD_ArticleRepository :IBaseRepository<YD_Article>
    {
      
    }
	
}