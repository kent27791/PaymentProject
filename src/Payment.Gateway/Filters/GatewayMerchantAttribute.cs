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
    public class GatewayMerchantAttribute : TypeFilterAttribute
    {
        public GatewayMerchantAttribute() : base(typeof(GatewayMerchantFilter))
        {

        }
    }
    //http://www.softawareblog.com/combining-basic-authentication-with-forms-authentication/
    public class GatewayMerchantFilter : IActionFilter
    {
        private readonly ILogger<GatewayMerchantFilter> _logger;
        private readonly IMerchantService _merchantService;
        public GatewayMerchantFilter(ILogger<GatewayMerchantFilter> logger, IMerchantService merchantService)
        {
            _logger = logger;
            _merchantService = merchantService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
