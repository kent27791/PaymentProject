using Payment.Core.Domain.Payment;
using Payment.Data.DatabaseContext;
using Payment.Core.Data;

namespace Payment.Service.Merchants
{
    public class MerchantService : BaseService<PaymentContext, Merchant, string>, IMerchantService
    {
        public MerchantService(IRepository<PaymentContext, Merchant, string> repository) : base(repository)
        {

        }
    }
}
