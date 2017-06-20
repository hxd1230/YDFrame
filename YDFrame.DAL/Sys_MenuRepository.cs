using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YDFrame.IDAL;
using YDFrame.Models;

namespace YDFrame.DAL
{
    /************************************************************************************
         * Copyright (c) 2017  All Rights Reserved.
         * CLR版本： 4.0.30319.42000
         * 机器名称：DESKTOP-C7IEETR
         * 公司名称：南京马普科技有限公司
         * 文件名：  HomeRepository
         * 版本号：  V1.0.0.0
         * 唯一标识：14750810-a754-4f48-b0cd-bbdb6cb31327
         * 当前的用户域：DESKTOP-C7IEETR
         * 创建人：  hexd 贺晓冬
         * 电子邮箱：675556820@qq.com
         * 创建时间：2017/5/25 17:51:05
         * 描述    :
         * =====================================================================
        *************************************************************************************/
    public partial class Sys_MenuRepository : BaseRepository<Sys_Menu>, ISys_MenuRepository
    {
        public List<Sys_Menu> GetMenuByUserName(string userName)
        {
            using (YDFrameEntities db = new YDFrameEntities())
            {
                var query = (from a in db.Sys_User
                             where a.UserName == userName
                             join b in db.Sys_UserRole
                             on a.Id equals b.UserId
                             join c in db.Sys_RoleMenu
                             on b.RoleId equals c.RoleId
                             join d in db.Sys_Menu
                             on c.MenuId equals d.Id
                             select d
                             ).ToList();
                return query;
            }
        }
    }
}
