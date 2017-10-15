using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.Domain.Transactions
{
    public class SendOrderTransaction : BaseEntity<string>
    {
        public string UserNophone { get; set; }
        public int Amount { get; set; }
        public string Address { get; set; }
        public int CreatedOn { get; set; }
        public int Time { get; set; }
        public int Status { get; set; }
    }
}
