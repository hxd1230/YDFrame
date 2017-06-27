 

using YDFrame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YDFrame.IBLL
{
	
	public partial interface ISys_ErrorService : IBaseService<Sys_Error>
    {
       
    }   
	
	public partial interface ISys_LogService : IBaseService<Sys_Log>
    {
       
    }   
	
	public partial interface ISys_MenuService : IBaseService<Sys_Menu>
    {
       
    }   
	
	public partial interface ISys_RoleService : IBaseService<Sys_Role>
    {
       
    }   
	
	public partial interface ISys_RoleMenuService : IBaseService<Sys_RoleMenu>
    {
       
    }   
	
	public partial interface ISys_UserService : IBaseService<Sys_User>
    {
       
    }   
	
	public partial interface ISys_UserRoleService : IBaseService<Sys_UserRole>
    {
       
    }   
	
	public partial interface IWX_AccountService : IBaseService<WX_Account>
    {
       
    }   
	
	public partial interface IWX_TypeService : IBaseService<WX_Type>
    {
       
    }   
	
	public partial interface IYD_ArticleService : IBaseService<YD_Article>
    {
       
    }   
	
}