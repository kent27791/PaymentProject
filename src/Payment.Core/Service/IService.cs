using Payment.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.Service
{
    public interface IService<TContext, TEntity, TKey> 
        where TEntity : BaseEntity<TKey>
        where TContext : class
    {
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
    }
}
