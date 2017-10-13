using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Gateway.ViewModels;

namespace Payment.Gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/payment/order")]
    public class OrderController : PaymentController
    {
        public IActionResult Create(GcoinOrderRequestViewModel requestViewModel)
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