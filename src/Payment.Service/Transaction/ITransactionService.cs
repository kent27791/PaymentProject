using Payment.Core.Domain.Transactions;
using Payment.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.Service
{
    public interface ITransactionService : IService<PaymentContext, Transaction, string>
    {

    }
}
