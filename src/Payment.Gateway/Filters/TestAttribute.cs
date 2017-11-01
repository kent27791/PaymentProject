using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Gateway.Filters
{
    public class TestAttribute : ActionFilterAttribute
    {
        public bool IsTest { get; set; }
        public TestAttribute(TestClass test, bool isTest)
        {

        }
    }
    public class TestClass
    {
        public TestClass()
        {

        }
    }
}
