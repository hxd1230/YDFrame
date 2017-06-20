using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YDFrame.IDAL
{
    public partial interface IDbSession
    {
        DbContext Db { get; }
        int ExecuteSQL(string sql, params SqlParameter[] pms);
        List<T> ExecuteSelect<T>(string sql, params SqlParameter[] pms);
        int SaveChanges();
    }
}
