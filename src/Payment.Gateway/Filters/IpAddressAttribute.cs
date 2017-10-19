using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Payment.Service.Merchants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Gateway.Filters
{
    public class IpAddressAttribute : ActionFilterAttribute
    {
        private readonly ILogger<IpAddressAttribute> _logger;
        private readonly IMerchantService _merchantService;
        public IpAddressAttribute(ILogger<IpAddressAttribute> logger, IMerchantService merchantService)
        {
            _logger = logger;
            _merchantService = merchantService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
