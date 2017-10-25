using Microsoft.EntityFrameworkCore;
using Payment.Core.DatabaseContext;
using Payment.Core.Domain.Log;

namespace Payment.Data.DatabaseContext
{
    public class LogContext : DbContext, IDatabaseContext<LogContext>
    {
        public LogContext(DbContextOptions<LogContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemLog>().ToTable("SystemLog");
            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
