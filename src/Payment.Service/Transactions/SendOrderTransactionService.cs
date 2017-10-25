using Payment.Core.Domain.Payment;
using Payment.Data.DatabaseContext;
using Payment.Core.Data;

namespace Payment.Service.Transactions
{
    public class SendOrderTransactionService : BaseService<PaymentContext, SendOrderTransaction, string>, ISendOrderTransactionService
    {
        public SendOrderTransactionService(IRepository<PaymentContext, SendOrderTransaction, string> repository) : base(repository)
        {
           
        }
    }
}
