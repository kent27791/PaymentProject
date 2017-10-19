using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.Domain.Members
{
    public class Member : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
    }
}
