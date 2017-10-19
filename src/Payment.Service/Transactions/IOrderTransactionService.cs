using Payment.Core.Domain.Transactions;
using Payment.Core.Service;
using Payment.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Transactions
{
    public interface IOrderTransactionService : IService<PaymentContext, OrderTransaction, string>
    {

    }
}
