using Payment.Core.Domain.Payment;
using Payment.Data.DatabaseContext;
using Payment.Core.Data;
using System.Linq;

namespace Payment.Service.Transactions
{
    public class TransactionService : BaseService<PaymentContext, Transaction, string>, ITransactionService
    {
        private readonly ISendOrderTransactionService _sendOrderTransactionService;
        private readonly IOrderTransactionService _orderTransactionService;
        public TransactionService(IRepository<PaymentContext, Transaction, string> repository, ISendOrderTransactionService sendOrderTransactionService, IOrderTransactionService orderTransactionService) : base(repository)
        {
            _orderTransactionService = orderTransactionService;
            _sendOrderTransactionService = sendOrderTransactionService;
        }

        public ISendOrderTransactionService SendOrder
        {
            get { return _sendOrderTransactionService; }
        }

        public IOrderTransactionService Order
        {
            get { return _orderTransactionService; }
        }

        public Transaction GetByBcoinId(string bcoinId)
        {
            return _repository.Query().SingleOrDefault(t => t.BcoinId.Equals(bcoinId));
        }

        public Transaction GetByGcoinId(string gcoinId)
        {
            return _repository.Query().SingleOrDefault(t => t.GcoinId.Equals(gcoinId));
        }

        public Transaction GetByIdOrBcoinId(string id, string bcoinId)
        {
            return _repository.Query().SingleOrDefault(t => t.Id.Equals(id) || t.BcoinId.Equals(bcoinId));
        }

        public bool IsExistBcoinId(string bcoinId)
        {
            return _repository.Query().Any(t => t.BcoinId.Equals(bcoinId));
        }
    }
}
