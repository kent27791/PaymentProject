using Microsoft.EntityFrameworkCore;
using Payment.Core.DatabaseContext;
using Payment.Core.Domain.Transactions;

namespace Payment.Data.DatabaseContext
{
    public class PaymentContext : DbContext, IDatabaseContext<PaymentContext>
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
            
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            base.OnModelCreating(modelBuilder);
        }
    }
}
