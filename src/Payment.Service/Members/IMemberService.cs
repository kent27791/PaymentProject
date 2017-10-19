using Payment.Core.Domain.Members;
using Payment.Core.Service;
using Payment.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Members
{
    public interface IMemberService : IService<PaymentContext, Member, int>
    {
    }
}
