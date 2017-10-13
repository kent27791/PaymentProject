using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.DatabaseContext
{
    public interface IDatabaseContext<TContext> where TContext : class
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
