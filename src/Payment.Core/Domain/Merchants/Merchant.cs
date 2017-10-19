using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.Domain.Mertchants
{
    public class Merchant : BaseEntity<string>
    {
        public string MerchantKey { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string UrlCallback { get; set; }
        public string UrlRedirect { get; set; }
        public string IpAllowed { get; set; }
    }
}
