using Payment.Core.Domain.Payment;
using Payment.Data.DatabaseContext;
using Payment.Core.Data;

namespace Payment.Service.Members
{
    public class MemberService : BaseService<PaymentContext, Member, int>, IMemberService
    {
        public MemberService(IRepository<PaymentContext, Member, int> repository) : base(repository)
        {

        }
    }
}
