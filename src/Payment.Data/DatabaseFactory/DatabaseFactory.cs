using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Payment.Core.DatabaseContext;
using Payment.Core.DatabaseFactory;
using Payment.Data.DatabaseContext;
using System;

namespace Payment.Data.DatabaseFactory
{
    public class DatabaseFactory : IDatabaseFactory
    {
        public DatabaseFactory(IServiceProvider serviceProvider)
        {
            
        }
    }
}
