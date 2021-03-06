﻿using System;
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
using Payment.Core.Data;
using Payment.Data.Repository;

using Payment.Data.DatabaseContext;
using Payment.Core.Configuration;
using Payment.Gateway.Extentions;
using Payment.Core.DatabaseContext;
using Payment.Service.Log;
using Payment.Service.Transactions;

using Payment.Core.Domain.Members;
using Payment.Core.Domain.Mertchants;
using Payment.Core.Domain.Transactions;
using Payment.Core.Domain.SystemLogs;
using Payment.Service.Members;
using Payment.Service.Merchants;
using Payment.Gateway.Filters;

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
            services.AddCustomizedSwagger();

            services.AddSingleton<IDatabaseContext<PaymentContext>, PaymentContext>();
            services.AddSingleton<IDatabaseContext<LogContext>, LogContext>();

            services.AddTransient<IRepository<PaymentContext, Transaction, string>, Repository<PaymentContext, Transaction, string>>();
            services.AddTransient<IRepository<PaymentContext, OrderTransaction, string>, Repository<PaymentContext, OrderTransaction, string>>();
            services.AddTransient<IRepository<PaymentContext, SendOrderTransaction, string>, Repository<PaymentContext, SendOrderTransaction, string>>();
            services.AddTransient<IRepository<PaymentContext, Member, int>, Repository<PaymentContext, Member, int>>();
            services.AddTransient<IRepository<PaymentContext, Merchant, string>, Repository<PaymentContext, Merchant, string>>();
            services.AddTransient<IRepository<LogContext, SystemLog, int>, Repository<LogContext, SystemLog, int>>();

            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IOrderTransactionService, OrderTransactionService>();
            services.AddTransient<ISendOrderTransactionService, SendOrderTransactionService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IMerchantService, MerchantService>();
            services.AddTransient<ISystemLogService, SystemLogService>();

            services.AddTransient<IpAddressAttribute>();

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
            app.UseCustomizedSwagger();
        }
    }
}
