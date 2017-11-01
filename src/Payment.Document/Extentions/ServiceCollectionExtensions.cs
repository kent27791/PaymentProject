using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Payment.Core.Data;
using Payment.Core.DatabaseContext;
using Payment.Core.Domain.Log;
using Payment.Core.Domain.Payment;
using Payment.Data.DatabaseContext;
using Payment.Data.Repository;
using Payment.Service.Log;
using Payment.Service.Members;
using Payment.Service.Merchants;
using Payment.Service.Transactions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Payment.Core.Configuration;
using Microsoft.Extensions.Configuration;

namespace Payment.Document.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            ISettings settings = configuration.GetSection("MySettings").Get<MySettings>();

            services.AddSingleton<ISettings>(settings);

            services.AddDbContextPool<PaymentContext>(options => options.UseSqlServer(settings.ConnectionStrings.Payment));
            services.AddDbContextPool<LogContext>(options => options.UseSqlServer(settings.ConnectionStrings.Log));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

            return services;
        }
    }
}
