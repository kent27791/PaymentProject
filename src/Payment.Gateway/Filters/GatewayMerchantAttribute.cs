using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Payment.Service.Log;
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
    public class GatewayMerchantFilter : IActionFilter
    {
        private readonly ISystemLogService _systemLogService;
        public GatewayMerchantFilter(ISystemLogService systemLogService)
        {
            _systemLogService = systemLogService;
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
