using Social.Data.Mapping;
using Social.Data.Model;
using Social.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Social.Services.Base
{
    #region Read/Write Services
    public interface IServiceBase<T> where T : BaseEntity
    {
        void SaveChanges();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(string id);
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
    }

    public class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected IRepositoryBase<T> _repository;

        public ServiceBase(IUnitOfWork unitOfWork, IRepositoryBase<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        #region Implementation
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            _repository.Delete(where);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _repository.Get(where);
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(string id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _repository.GetMany(where);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
        #endregion
    }

    public interface INoAuditServiceBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(string id);
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
    }

    public class NoAuditServiceBase<T> : INoAuditServiceBase<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected INoAuditRepositoryBase<T> _repository;

        public NoAuditServiceBase(IUnitOfWork unitOfWork, INoAuditRepositoryBase<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            _repository.Delete(where);
        }

        public virtual T GetById(string id)
        {
            return _repository.GetById(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _repository.GetMany(where);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return _repository.Get(where);
        }

        #endregion
    }

    #endregion

}
