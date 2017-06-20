 

using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using YDFrame.IDAL;
namespace YDFrame.DALFactory
{
	public partial class DbSession : IDbSession
    {
	
		private ISys_LoginLogRepository _Sys_LoginLogRepository;
        public ISys_LoginLogRepository Sys_LoginLogRepository
        {
            get
            {
                if(_Sys_LoginLogRepository == null)
                {
				
                    _Sys_LoginLogRepository =AbstractFactory.CreateSys_LoginLogRepository();
                }
                return _Sys_LoginLogRepository;
            }
            set { _Sys_LoginLogRepository = value; }
        }
	
		private ISys_MenuRepository _Sys_MenuRepository;
        public ISys_MenuRepository Sys_MenuRepository
        {
            get
            {
                if(_Sys_MenuRepository == null)
                {
				
                    _Sys_MenuRepository =AbstractFactory.CreateSys_MenuRepository();
                }
                return _Sys_MenuRepository;
            }
            set { _Sys_MenuRepository = value; }
        }
	
		private ISys_RoleRepository _Sys_RoleRepository;
        public ISys_RoleRepository Sys_RoleRepository
        {
            get
            {
                if(_Sys_RoleRepository == null)
                {
				
                    _Sys_RoleRepository =AbstractFactory.CreateSys_RoleRepository();
                }
                return _Sys_RoleRepository;
            }
            set { _Sys_RoleRepository = value; }
        }
	
		private ISys_RoleMenuRepository _Sys_RoleMenuRepository;
        public ISys_RoleMenuRepository Sys_RoleMenuRepository
        {
            get
            {
                if(_Sys_RoleMenuRepository == null)
                {
				
                    _Sys_RoleMenuRepository =AbstractFactory.CreateSys_RoleMenuRepository();
                }
                return _Sys_RoleMenuRepository;
            }
            set { _Sys_RoleMenuRepository = value; }
        }
	
		private ISys_UserRepository _Sys_UserRepository;
        public ISys_UserRepository Sys_UserRepository
        {
            get
            {
                if(_Sys_UserRepository == null)
                {
				
                    _Sys_UserRepository =AbstractFactory.CreateSys_UserRepository();
                }
                return _Sys_UserRepository;
            }
            set { _Sys_UserRepository = value; }
        }
	
		private ISys_UserRoleRepository _Sys_UserRoleRepository;
        public ISys_UserRoleRepository Sys_UserRoleRepository
        {
            get
            {
                if(_Sys_UserRoleRepository == null)
                {
				
                    _Sys_UserRoleRepository =AbstractFactory.CreateSys_UserRoleRepository();
                }
                return _Sys_UserRoleRepository;
            }
            set { _Sys_UserRoleRepository = value; }
        }
	
		private IWX_AccountRepository _WX_AccountRepository;
        public IWX_AccountRepository WX_AccountRepository
        {
            get
            {
                if(_WX_AccountRepository == null)
                {
				
                    _WX_AccountRepository =AbstractFactory.CreateWX_AccountRepository();
                }
                return _WX_AccountRepository;
            }
            set { _WX_AccountRepository = value; }
        }
	
		private IWX_TypeRepository _WX_TypeRepository;
        public IWX_TypeRepository WX_TypeRepository
        {
            get
            {
                if(_WX_TypeRepository == null)
                {
				
                    _WX_TypeRepository =AbstractFactory.CreateWX_TypeRepository();
                }
                return _WX_TypeRepository;
            }
            set { _WX_TypeRepository = value; }
        }
	
		private IYD_ArticleRepository _YD_ArticleRepository;
        public IYD_ArticleRepository YD_ArticleRepository
        {
            get
            {
                if(_YD_ArticleRepository == null)
                {
				
                    _YD_ArticleRepository =AbstractFactory.CreateYD_ArticleRepository();
                }
                return _YD_ArticleRepository;
            }
            set { _YD_ArticleRepository = value; }
        }
	}	
}