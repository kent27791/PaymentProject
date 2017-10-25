using System.Collections.Generic;

namespace Payment.Core.Domain.Payment
{
    public class SendOrderTransaction : BaseEntity<string>
    {
        public string UserNophone { get; set; }
        public int Amount { get; set; }
        public string Address { get; set; }
        public int CreatedOn { get; set; }
        public int Time { get; set; }
        public int Status { get; set; }

        //public Transaction Transaction { get; set; }
    }
}
