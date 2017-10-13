using Payment.Core.Data;
using Payment.Core.Domain.Transactions;
using Payment.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Payment.Data.DatabaseContext;
using Payment.Service.Log;

namespace Payment.Service
{
    public class TransactionService : BaseService<PaymentContext, Transaction, string>, ITransactionService
    {
        private readonly ISystemLogService _systemLogService;
        public TransactionService(IRepository<PaymentContext, Transaction, string> repository, ISystemLogService systemLogService) : base(repository)
        {
            _systemLogService = systemLogService;
        }
    }
}
