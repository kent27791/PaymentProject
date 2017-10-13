using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.Configuration
{
    public class MySettings : ISettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }
}
