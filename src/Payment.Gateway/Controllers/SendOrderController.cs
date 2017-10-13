using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Gateway.ViewModels;
using Payment.Gateway.Extentions;
using System.Net.Http;

namespace Payment.Gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/sendorder")]
    public class SendOrderController : Controller
    {
        [HttpGet]
        [Route("create")]
        public IActionResult Create([FromQuery] GcoinSendOrderRequestViewModel requestViewModel, string callback_data)
        {
            //HttpResponseMessage response = GcoinExtentions.SendGcoin<GcoinSendOrderRequestViewModel>("/gateway/send_order?", requestViewModel);
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