using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using YDFrame.DALFactory;
namespace YDFrame.DAL
{
    public class BaseRepository<T> where T : class,new()
    {
        DbContext db = DbContextFactory.CreateDbContext();

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().AsNoTracking().Where<T>(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            var temp = db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)//升序
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            var temp = db.Set<T>().Where<T>(whereLambda);
            if (isAsc)//升序
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;

        }


        public bool UpdateEntity(T entity)
        {
            db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return true;
        }

        public bool DeleteEntity(T entity)
        {
            db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return true;
        }

        public T AddEntity(T entity)
        {
            db.Set<T>().Add(entity);

            return entity;
        }
    }
}
