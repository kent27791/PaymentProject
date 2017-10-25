using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Core.Domain;
using Payment.Core.Domain.Payment;

namespace Payment.Core.Mapping.Payment
{
    public class TransactionMap : BaseEntityMap<Transaction, string>
    {
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            base.Configure(builder);
            builder.ToTable("Transaction");
        }
    }
}
