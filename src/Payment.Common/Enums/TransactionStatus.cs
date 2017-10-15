using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Common.Enums
{
    public enum TransactionStatus
    {
        Init = 0,
        Successed = 1,
        Failed = 2,
        Callback = 3
    }
}
