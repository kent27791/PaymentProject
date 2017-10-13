using Microsoft.EntityFrameworkCore;
using Payment.Core.DatabaseContext;
using Payment.Core.Domain.SystemLogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.DatabaseContext
{
    public class LogContext : DbContext, IDatabaseContext<LogContext>
    {
        public LogContext(DbContextOptions<LogContext> options) : base(options)
        {

        }

        public DbSet<SystemLog> SystemLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemLog>().ToTable("SystemLog");
            base.OnModelCreating(modelBuilder);
        }
    }
}
