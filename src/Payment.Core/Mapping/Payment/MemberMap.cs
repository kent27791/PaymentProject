using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Core.Domain;
using Payment.Core.Domain.Payment;

namespace Payment.Core.Mapping.Payment
{
    public class MemberMap : BaseEntityMap<Member, int>
    {
        public override void Configure(EntityTypeBuilder<Member> builder)
        {
            base.Configure(builder);
            builder.ToTable("Member");
        }
    }
}
