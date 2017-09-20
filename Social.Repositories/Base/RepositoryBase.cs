using Social.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repositories.Base
{
    #region Audit repositories
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
    }

    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: BaseEntity
    {
        #region Properties
        private readonly IDbSet<T> dbSet;
        protected SocialContext DbContext { get; }
        #endregion

        protected RepositoryBase(SocialContext dataContext)
        {
            DbContext   = dataContext;
            dbSet       = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.UpdatedOn = DateTime.UtcNow;
            dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public virtual T GetById(string id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IQueryable<T> objects = dbSet.Where(where);
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public virtual void Update(T entity)
        {
            entity.UpdatedOn = DateTime.UtcNow;
            dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        #endregion
    }
    #endregion

    #region NoAudit repositories
    public interface INoAuditRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
    }

    public abstract class NoAuditRepostitoryBase<T> : INoAuditRepositoryBase<T> where T : class
    {
        #region Properties
        private readonly IDbSet<T> dbSet;
        protected SocialContext DbContext { get; }
        #endregion

        protected NoAuditRepostitoryBase(SocialContext dataContext)
        {
            DbContext = dataContext;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IQueryable<T> objects = dbSet.Where<T>(where);
            foreach(T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where<T>(where).FirstOrDefault();
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public virtual T GetById(string id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
        #endregion
    }
    #endregion

    public interface IAggregateService
    {
        adsf
    }

}
