using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Payment.Core.Service;
using Payment.Service;
using Payment.Core.Data;
using Payment.Data.Repository;
using Payment.Core.Domain.Transactions;
using Payment.Core.DatabaseFactory;
using Payment.Data.DatabaseFactory;
using Payment.Data.DatabaseContext;
using Payment.Core.Configuration;
using Payment.Gateway.Extentions;
using Payment.Core.DatabaseContext;
using Payment.Core.Domain.SystemLogs;
using Payment.Service.Log;

namespace Payment.Gateway
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly ISettings _settings;
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _settings = configuration.GetCustomizedSettings();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCustomizedSettings(_settings);
            services.AddCustomizedMvc();
            services.AddCustomizedDataStore(_settings);
            services.AddCustomizedAutoMapper();

            services.AddSingleton<IDatabaseContext<PaymentContext>, PaymentContext>();
            services.AddSingleton<IDatabaseContext<LogContext>, LogContext>();

            services.AddTransient<IRepository<PaymentContext, Transaction, string>, Repository<PaymentContext, Transaction, string>>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IRepository<LogContext, SystemLog, int>, Repository<LogContext, SystemLog, int>>();
            services.AddTransient<ISystemLogService, SystemLogService>();
            return services.Build(_configuration, _hostingEnvironment);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePagesWithReExecute("/Home/ErrorWithCode/{0}");
            app.UseCustomizedStaticFiles(env);
            app.UseCustomizedIdentity();
            app.UseCustomizedMvc();
            app.UseCustomizedLogger(env, loggerFactory);
        }
    }
}
