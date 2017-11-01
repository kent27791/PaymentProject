using System.Collections.Generic;

namespace Payment.Core.Domain.Payment
{
    public class OrderTransaction : BaseEntity<string>
    {
        public string Address { get; set; }
        public int AmountRequested { get; set; }
        public int Amount { get; set; }
        public int CreatedOn { get; set; }
        public int? Time { get; set; }
        public int Status { get; set; }

        public Transaction Transaction { get; set; }
    }
}
