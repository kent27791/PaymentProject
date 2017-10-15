using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.Domain.Transactions
{
    public class Transaction : BaseEntity<string>
    {
        public string BcoinId { get; set; }
        public string GcoinId { get; set; }
        public int MerchantId { get; set; }
        public int MemberId { get; set; }
        public int Status { get; set; }
        public string Result { get; set; }
    }
}
