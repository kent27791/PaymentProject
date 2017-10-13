using Microsoft.EntityFrameworkCore;
using Payment.Core.Data;
using Payment.Core.DatabaseContext;
using Payment.Core.DatabaseFactory;
using Payment.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Payment.Data.Repository
{
    public class Repository<TContext, TEntity, TKey> : IRepository<TContext, TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TContext : class
    {
        protected readonly IDatabaseContext<TContext> _databaseContext;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(IDatabaseContext<TContext> databaseContext)
        {
            _databaseContext = databaseContext;
            _dbSet = _databaseContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Query()
        {
            return _dbSet;
        }
    }
}
