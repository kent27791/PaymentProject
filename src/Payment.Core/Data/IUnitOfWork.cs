using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.Data
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        void Commit();
    }
}
