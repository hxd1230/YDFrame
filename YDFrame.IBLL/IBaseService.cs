using System;
using System.Linq;
using System.Linq.Expressions;
using YDFrame.IDAL;

namespace YDFrame.IBLL
{
    public interface IBaseService<T> where T : class,new()
    {
        IDbSession DbSession { get; }
        IBaseRepository<T> CurrentRepository { get; set; }
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc);
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc);
        bool UpdateEntity(T entity);
        bool DeleteEntity(T entity);
        T AddEntity(T entity);
    }
}
