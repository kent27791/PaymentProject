using Microsoft.EntityFrameworkCore;
using Payment.Core.Data;
using Payment.Core.DatabaseContext;
using Payment.Core.Domain;
using Payment.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Payment.Service
{
    public class BaseService<TContext, TEntity, TKey> : IService<TContext, TEntity, TKey> 
        where TEntity : BaseEntity<TKey>
        where TContext : class
    {
        protected readonly IRepository<TContext, TEntity, TKey> _repository;

        public BaseService(IRepository<TContext, TEntity, TKey> repository)
        {
            this._repository = repository;
        }

        public TEntity Get(TKey key)
        {
            return _repository.Query().SingleOrDefault(e => e.Id.Equals(key));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.Query().ToList();
        }

        public TEntity Add(TEntity entity)
        {
            return _repository.Add(entity);
        }
    }
}
