using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Payment.Service.Log;
using Payment.Service.Transactions;
using Payment.Gateway.Filters;

namespace Payment.Gateway.Controllers
{
    [Route("api/[controller]")]
    //[ServiceFilter(typeof(GatewayAuthorizationAttribute))]
    [TypeFilter(typeof(TestAttribute), Arguments =  new object[] { true })]
    //[GatewayMerchant(IsTest = true)]
    //[GatewayAuthorizationAttribute()]
    public class ValuesController : Controller
    {
        private readonly ITransactionService _transactionService;
        public ValuesController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var test = _transactionService.GetAll();
            var test_1 = _transactionService.Order.GetAll();
            return Json("Ok");
        }
    }
}
