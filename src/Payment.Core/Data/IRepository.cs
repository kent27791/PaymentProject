using Microsoft.EntityFrameworkCore;
using Payment.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payment.Core.Data
{
    public interface IRepository<TContext, TEntity, TKey> 
        where TEntity : BaseEntity<TKey>
        where TContext : class
    {
        IQueryable<TEntity> Query();
    }
}
