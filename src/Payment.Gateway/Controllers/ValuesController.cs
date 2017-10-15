using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Payment.Service.Log;
using Payment.Service.Transactions;

namespace Payment.Gateway.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ISystemLogService _systemLogService;
        public ValuesController(ITransactionService transactionService, ISystemLogService systemLogService)
        {
            _transactionService = transactionService;
            _systemLogService = systemLogService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json("Ok");
        }
    }
}
