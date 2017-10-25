using Payment.Core.Service;
using Payment.Core.Domain.Payment;
using Payment.Data.DatabaseContext;

namespace Payment.Service.Members
{
    public interface IMemberService : IService<PaymentContext, Member, int>
    {
    }
}
