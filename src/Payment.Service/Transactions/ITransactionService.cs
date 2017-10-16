

using Payment.Core.Service;
using Payment.Core.Domain.Transactions;
using Payment.Data.DatabaseContext;

namespace Payment.Service.Transactions
{
    public interface ITransactionService : IService<PaymentContext, Transaction, string>
    {
        ISendOrderTransactionService SendOrder { get; }
        bool IsExistBcoinId(string bcoinId);
        Transaction GetByBcoinId(string bcoinId);
        Transaction GetByGcoinId(string gcoinId);
        Transaction GetByIdOrBcoinId(string id, string bcoinId);
    }
}
