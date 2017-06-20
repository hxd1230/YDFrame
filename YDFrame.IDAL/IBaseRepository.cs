using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YDFrame.IDAL
{
    public interface IBaseRepository<T> where T : class,new()
    {
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc);
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc);
        bool UpdateEntity(T entity);
        bool DeleteEntity(T entity);
        T AddEntity(T entity);
        //List<T1> ExecuteSql<T1>(string sql, params SqlParameter[] pms);
    }
}
