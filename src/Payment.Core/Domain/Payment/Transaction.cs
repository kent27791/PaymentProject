using System.Collections.Generic;

namespace Payment.Core.Domain.Payment
{
    public class Transaction : BaseEntity<string>
    {
        public string BcoinId { get; set; }
        public string GcoinId { get; set; }
        public int MerchantId { get; set; }
        public int MemberId { get; set; }
        public int Status { get; set; }
        public string Result { get; set; }

        public OrderTransaction OrderTransaction { get; set; }
        //public SendOrderTransaction SendOrderTransaction { get; set; }
    }
}
