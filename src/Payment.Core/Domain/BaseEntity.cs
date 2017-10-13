using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.Domain
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
