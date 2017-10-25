using Payment.Core.Domain.Payment;
using Payment.Data.DatabaseContext;
using Payment.Core.Data;

namespace Payment.Service.Transactions
{
    public class OrderTransactionService : BaseService<PaymentContext, OrderTransaction, string>, IOrderTransactionService
    {
        public OrderTransactionService(IRepository<PaymentContext, OrderTransaction, string> repository) : base(repository)
        {

        }
    }
}
