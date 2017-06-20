using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using YDFrame.Models;

namespace YDFrame.DALFactory
{
    /************************************************************************************
         * Copyright (c) 2017  All Rights Reserved.
         * CLR版本： 4.0.30319.42000
         * 机器名称：DESKTOP-C7IEETR
         * 公司名称：南京马普科技有限公司
         * 文件名：  DbContextFactory
         * 版本号：  V1.0.0.0
         * 唯一标识：a6288333-6f22-41d7-a222-5d17763c2ef9
         * 当前的用户域：DESKTOP-C7IEETR
         * 创建人：  hexd 贺晓冬
         * 电子邮箱：675556820@qq.com
         * 创建时间：2017/6/14 14:52:03
         * 描述    :
         * =====================================================================
        *************************************************************************************/
    public static class DbContextFactory
    {
        /// <summary>
        /// 保证EF上下文对象线程内唯一.
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateDbContext()
        {
            DbContext db = (DbContext)CallContext.GetData("db");
            if (db == null)
            {
                db = new YDFrameEntities();
                CallContext.SetData("db", db);
            }
            return db;
        }
    }
}
