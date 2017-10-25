using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Core.Domain;
using Payment.Core.Domain.Payment;

namespace Payment.Core.Mapping.Payment
{
    public class SendOrderTransactionMap : BaseEntityMap<SendOrderTransaction, string>
    {

        public override void Configure(EntityTypeBuilder<SendOrderTransaction> builder)
        {
            base.Configure(builder);
            builder.ToTable("SendOrderTransaction");
        }
    }
}
