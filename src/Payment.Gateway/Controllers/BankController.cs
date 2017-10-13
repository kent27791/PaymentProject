using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Payment.Gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/bank")]
    public class BankController : Controller
    {
        public IActionResult Create()
        {
            return null;
        }

        public IActionResult Check()
        {
            return null;
        }

        public IActionResult History()
        {
            return null;
        }
    }
}