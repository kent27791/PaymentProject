using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Core.Domain;
using Payment.Core.Domain.Payment;

namespace Payment.Core.Mapping.Payment
{
    public class OrderTransactionMap : BaseEntityMap<OrderTransaction, string>
    {
        public override void Configure(EntityTypeBuilder<OrderTransaction> builder)
        {
            base.Configure(builder);
            builder.ToTable("OrderTransaction");
        }
    }
}
