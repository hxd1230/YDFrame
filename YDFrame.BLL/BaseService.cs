using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YDFrame.DALFactory;
using YDFrame.IDAL;

namespace YDFrame.BLL
{
    public abstract class BaseService<T> where T : class,new()
    {
        public IDbSession DbSession
        {
            get
            {
                return DbSessionFactory.CreateDbSession();
            }
        }
        public abstract void SetCurrentRepository();
        public BaseService()
        {
            SetCurrentRepository();
        }
        public IDAL.IBaseRepository<T> CurrentRepository { get; set; }
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentRepository.LoadEntities(whereLambda);
        }
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            return CurrentRepository.LoadPageEntities(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, isAsc);
        }
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            return CurrentRepository.LoadPageEntities(pageIndex, pageSize, whereLambda, orderbyLambda, isAsc);
        }
        public bool UpdateEntity(T entity)
        {
            CurrentRepository.UpdateEntity(entity);
            return DbSession.SaveChanges() > 0;
        }
        public bool DeleteEntity(T entity)
        {
            CurrentRepository.DeleteEntity(entity);
            return DbSession.SaveChanges() > 0;
        }
        public T AddEntity(T entity)
        {
            CurrentRepository.AddEntity(entity);
            DbSession.SaveChanges();
            return entity;
        }
    }
}
