using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Gateway.ViewModels;
using Payment.Gateway.Extentions;
using System.Net.Http;
using AutoMapper;
using Payment.Gateway.Filters;
using Microsoft.Extensions.Logging;

namespace Payment.Gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/sendorder")]
    //[GatewayMerchant]
    public class SendOrderController : Controller
    {
        private readonly IMapper _mapper;
        public SendOrderController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            _mapper = mapper;
            ILogger logger = loggerFactory.CreateLogger("PaymentGateway");
            logger.LogInformation("test");
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create(GatewaySendOrderRequestViewModel requestViewModel)
        {
            var gcoinSendOrderRequestViewModel = _mapper.Map<GatewaySendOrderRequestViewModel, GcoinSendOrderRequestViewModel>(requestViewModel);
            //HttpResponseMessage response = GcoinExtentions.SendGcoin<GcoinSendOrderRequestViewModel>("/gateway/send_order?", requestViewModel);
            return Json("");
        }

        [HttpGet]
        [Route("check")]
        public IActionResult Check()
        {
            return null;
        }

        [HttpGet]
        [Route("history")]
        public IActionResult History()
        {
            return null;
        }
    }
}