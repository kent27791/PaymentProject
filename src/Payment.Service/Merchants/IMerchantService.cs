using Payment.Core.Domain.Mertchants;
using Payment.Core.Service;
using Payment.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Merchants
{
    public interface IMerchantService : IService<PaymentContext, Merchant, string>
    {

    }
}
