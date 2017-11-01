using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Gateway;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Test
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration, IHostingEnvironment hostingEnvironment) : base(configuration, hostingEnvironment)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            
        }
    }
}
