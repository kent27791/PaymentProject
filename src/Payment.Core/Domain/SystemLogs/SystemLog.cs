using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.Domain.SystemLogs
{
    public class SystemLog : BaseEntity<int>
    {
        public string Value { get; set; }
    }
}
