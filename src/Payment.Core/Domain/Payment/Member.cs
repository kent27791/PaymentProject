using System.Collections.Generic;

namespace Payment.Core.Domain.Payment
{
    public class Member : BaseEntity<int>
    {
        public Member()
        {
            this.Merchants = new List<Merchant>();
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public IList<Merchant> Merchants { get; set; }
    }
}
