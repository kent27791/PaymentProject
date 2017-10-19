using Payment.Core.Data;
using Payment.Core.Domain.Members;
using Payment.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Members
{
    public class MemberService : BaseService<PaymentContext, Member, int>, IMemberService
    {
        public MemberService(IRepository<PaymentContext, Member, int> repository) : base(repository)
        {

        }
    }
}
