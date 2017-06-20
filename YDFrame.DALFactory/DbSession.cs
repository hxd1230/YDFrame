using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using YDFrame.IDAL;

namespace YDFrame.DALFactory
{
    /************************************************************************************
         * Copyright (c) 2017  All Rights Reserved.
         * CLR版本： 4.0.30319.42000
         * 机器名称：DESKTOP-C7IEETR
         * 公司名称：南京马普科技有限公司
         * 文件名：  DbSession
         * 版本号：  V1.0.0.0
         * 唯一标识：4b6a39c0-cbab-4654-9f4e-ccb9b8bc8223
         * 当前的用户域：DESKTOP-C7IEETR
         * 创建人：  hexd 贺晓冬
         * 电子邮箱：675556820@qq.com
         * 创建时间：2017/6/14 14:49:11
         * 描述    :
         * =====================================================================
        *************************************************************************************/
    public partial class DbSession : IDbSession
    {
        public DbContext Db
        {
            get {return DbContextFactory.CreateDbContext(); }
        }

        public int ExecuteSQL(string sql, params SqlParameter[] pms)
        {
            return Db.Database.ExecuteSqlCommand(sql, pms);
        }

        public List<T> ExecuteSelect<T>(string sql, params SqlParameter[] pms)
        {
            return this.Db.Database.SqlQuery<T>(sql, pms).ToList();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
