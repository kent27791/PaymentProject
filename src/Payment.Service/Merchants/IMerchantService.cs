using Payment.Core.Service;
using Payment.Core.Domain.Payment;
using Payment.Data.DatabaseContext;

namespace Payment.Service.Merchants
{
    public interface IMerchantService : IService<PaymentContext, Merchant, string>
    {

    }
}
