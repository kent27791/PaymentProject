using Microsoft.EntityFrameworkCore;
using Payment.Core.Data;
using Payment.Core.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> 
        where TContext : DbContext
    {
        private readonly IDatabaseContext<TContext> _databaseContext;

        public UnitOfWork(IDatabaseContext<TContext> databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Commit()
        {
            _databaseContext.Commit();
        }
    }
}
