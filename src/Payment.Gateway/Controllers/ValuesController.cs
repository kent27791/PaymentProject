using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payment.Core.Service;
using Payment.Core.Configuration;
using Payment.Service.Log;
using Payment.Data.DatabaseContext;

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
        public IEnumerable<dynamic> Get()
        {
            return _systemLogService.GetAll();
        }
    }
}
