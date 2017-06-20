using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YDFrame.Models;

namespace YDFrame.IBLL
{
    public partial interface ISys_MenuService : IBaseService<Sys_Menu>
    {
        List<Sys_Menu> GetMenuByUserName(string userName);
    }
}
