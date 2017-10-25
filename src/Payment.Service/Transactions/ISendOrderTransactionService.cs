using Payment.Core.Service;
using Payment.Core.Domain.Payment;
using Payment.Data.DatabaseContext;

namespace Payment.Service.Transactions
{
    public interface ISendOrderTransactionService : IService<PaymentContext, SendOrderTransaction, string>
    {
    }
}
