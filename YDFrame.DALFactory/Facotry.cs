 

using System.Reflection;
using YDFrame.Common;
using YDFrame.IDAL;
namespace YDFrame.DALFactory
{
    public partial class AbstractFactory
    {
		
	    public static ISys_ErrorRepository CreateSys_ErrorRepository()
        {
            string classFulleName = ConfigUtil.GetAppSettings("NameSpace") + ".Sys_ErrorRepository";
			string assembly = ConfigUtil.GetAppSettings("DalAssembly");
            var obj  = CreateInstance( classFulleName,assembly);
            return obj as ISys_ErrorRepository;
        }
		
	    public static ISys_IconRepository CreateSys_IconRepository()
        {
            string classFulleName = ConfigUtil.GetAppSettings("NameSpace") + ".Sys_IconRepository";
			string assembly = ConfigUtil.GetAppSettings("DalAssembly");
            var obj  = CreateInstance( classFulleName,assembly);
            return obj as ISys_IconRepository;
        }
		
	    public static ISys_LogRepository CreateSys_LogRepository()
        {
            string classFulleName = ConfigUtil.GetAppSettings("NameSpace") + ".Sys_LogRepository";
			string assembly = ConfigUtil.GetAppSettings("DalAssembly");
            var obj  = CreateInstance( classFulleName,assembly);
            return obj as ISys_LogRepository;
        }
		
	    public static ISys_MenuRepository CreateSys_MenuRepository()
        {
            string classFulleName = ConfigUtil.GetAppSettings("NameSpace") + ".Sys_MenuRepository";
			string assembly = ConfigUtil.GetAppSettings("DalAssembly");
            var obj  = CreateInstance( classFulleName,assembly);
            return obj as ISys_MenuRepository;
        }
		
	    public static ISys_RoleRepository CreateSys_RoleRepository()
        {
            string classFulleName = ConfigUtil.GetAppSettings("NameSpace") + ".Sys_RoleRepository";
			string assembly = ConfigUtil.GetAppSettings("DalAssembly");
            var obj  = CreateInstance( classFulleName,assembly);
            return obj as ISys_RoleRepository;
        }
		
	    public static ISys_RoleMenuRepository CreateSys_RoleMenuRepository()
        {
            string classFulleName = ConfigUtil.GetAppSettings("NameSpace") + ".Sys_RoleMenuRepository";
			string assembly = ConfigUtil.GetAppSettings("DalAssembly");
            var obj  = CreateInstance( classFulleName,assembly);
            return obj as ISys_RoleMenuRepository;
        }
		
	    public static ISys_UserRepository CreateSys_UserRepository()
        {
            string classFulleName = ConfigUtil.GetAppSettings("NameSpace") + ".Sys_UserRepository";
			string assembly = ConfigUtil.GetAppSettings("DalAssembly");
            var obj  = CreateInstance( classFulleName,assembly);
            return obj as ISys_UserRepository;
        }
		
	    public static ISys_UserRoleRepository CreateSys_UserRoleRepository()
        {
            string classFulleName = ConfigUtil.GetAppSettings("NameSpace") + ".Sys_UserRoleRepository";
			string assembly = ConfigUtil.GetAppSettings("DalAssembly");
            var obj  = CreateInstance( classFulleName,assembly);
            return obj as ISys_UserRoleRepository;
        }
		
	    public static IWX_AccountRepository CreateWX_AccountRepository()
        {
            string classFulleName = ConfigUtil.GetAppSettings("NameSpace") + ".WX_AccountRepository";
			string assembly = ConfigUtil.GetAppSettings("DalAssembly");
            var obj  = CreateInstance( classFulleName,assembly);
            return obj as IWX_AccountRepository;
        }
		
	    public static IWX_TypeRepository CreateWX_TypeRepository()
        {
            string classFulleName = ConfigUtil.GetAppSettings("NameSpace") + ".WX_TypeRepository";
			string assembly = ConfigUtil.GetAppSettings("DalAssembly");
            var obj  = CreateInstance( classFulleName,assembly);
            return obj as IWX_TypeRepository;
        }
		
	    public static IYD_ArticleRepository CreateYD_ArticleRepository()
        {
            string classFulleName = ConfigUtil.GetAppSettings("NameSpace") + ".YD_ArticleRepository";
			string assembly = ConfigUtil.GetAppSettings("DalAssembly");
            var obj  = CreateInstance( classFulleName,assembly);
            return obj as IYD_ArticleRepository;
        }
	}
	
}