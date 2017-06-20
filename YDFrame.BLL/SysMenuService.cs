using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YDFrame.DAL;
using YDFrame.IBLL;
using YDFrame.IDAL;
using YDFrame.Models;

namespace YDFrame.BLL
{
    public partial class Sys_MenuService : BaseService<Sys_Menu>, ISys_MenuService
    {
        [Dependency]
        public ISys_MenuRepository _homeRepository { get; set; }
        public List<Sys_Menu> GetMenuByUserName(string userName)
        {
            return _homeRepository.GetMenuByUserName(userName);
        }
    }
}
