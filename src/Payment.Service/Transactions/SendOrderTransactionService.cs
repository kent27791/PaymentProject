using Payment.Core.Data;
using Payment.Core.Domain.Transactions;
using Payment.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Transactions
{
    public class SendOrderTransactionService : BaseService<PaymentContext, SendOrderTransaction, string>, ISendOrderTransactionService
    {
        public SendOrderTransactionService(IRepository<PaymentContext, SendOrderTransaction, string> repository) : base(repository)
        {
           
        }
    }
}
