using Payment.Core.Data;
using Payment.Core.Domain.Transactions;
using Payment.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Transactions
{
    public class OrderTransactionService : BaseService<PaymentContext, OrderTransaction, string>, IOrderTransactionService
    {
        public OrderTransactionService(IRepository<PaymentContext, OrderTransaction, string> repository) : base(repository)
        {

        }
    }
}
