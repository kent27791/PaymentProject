using Payment.Core.Data;
using Payment.Data.DatabaseContext;
using Payment.Service.Log;
using Payment.Core.Domain.Transactions;
using Payment.Service;

namespace Payment.Service.Transactions
{
    public class TransactionService : BaseService<PaymentContext, Transaction, string>, ITransactionService
    {
        private readonly ISendOrderTransactionService _sendOrderTransactionService;
        public TransactionService(IRepository<PaymentContext, Transaction, string> repository, ISendOrderTransactionService sendOrderTransactionService) : base(repository)
        {
            _sendOrderTransactionService = sendOrderTransactionService;
        }

        public ISendOrderTransactionService SendOrder
        {
            get { return _sendOrderTransactionService; }
        }
    }
}
