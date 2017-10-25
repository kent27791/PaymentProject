using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Core.Domain;
using Payment.Core.Domain.Payment;

namespace Payment.Core.Mapping.Payment
{
    public class MerchantMap : BaseEntityMap<Merchant, string>
    {
        public override void Configure(EntityTypeBuilder<Merchant> builder)
        {
            base.Configure(builder);
            builder.ToTable("Merchant");
        }
    }
}
