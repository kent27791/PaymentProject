﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<OrderTransaction> OrderTransactions { get; set; }
        public DbSet<SendOrderTransaction> SendOrderTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<OrderTransaction>().ToTable("OrderTransaction");
            modelBuilder.Entity<SendOrderTransaction>().ToTable("SendOrderTransaction");
            base.OnModelCreating(modelBuilder);
        }


        public void Commit()
        {
            SaveChanges();
        }

    }
}
