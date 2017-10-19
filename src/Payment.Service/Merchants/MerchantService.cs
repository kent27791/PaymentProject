using Payment.Core.Data;
using Payment.Core.Domain.Mertchants;
using Payment.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Merchants
{
    public class MerchantService : BaseService<PaymentContext, Merchant, string>, IMerchantService
    {
        public MerchantService(IRepository<PaymentContext, Merchant, string> repository) : base(repository)
        {

        }
    }
}
