using Microsoft.EntityFrameworkCore;
using Payment.Core.DatabaseContext;
using Payment.Core.Mapping.Payment;

namespace Payment.Data.DatabaseContext
{
    public class PaymentContext : DbContext, IDatabaseContext<PaymentContext>
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MemberMap());
            modelBuilder.ApplyConfiguration(new MerchantMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());
            modelBuilder.ApplyConfiguration(new OrderTransactionMap());
            modelBuilder.ApplyConfiguration(new SendOrderTransactionMap());
        }

        public void Commit()
        {
            SaveChanges();
        }

    }
}
