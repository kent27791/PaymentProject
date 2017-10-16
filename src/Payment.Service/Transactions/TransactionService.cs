using System.Linq;

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
