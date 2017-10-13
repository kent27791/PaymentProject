using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Payment.Core.Configuration;
using Payment.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Gateway.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static ISettings GetCustomizedSettings(this IConfiguration configuration)
        {
            ISettings settings = configuration.GetSection("MySettings").Get<MySettings>();
            return settings;
        }

        public static IServiceCollection AddCustomizedSettings(this IServiceCollection services, ISettings settings)
        {  
            services.AddSingleton<ISettings>(settings);
            return services;
        }

        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            return services;
        }

        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, ISettings settings)
        {
            services.AddDbContextPool<PaymentContext>(options => options.UseSqlServer(settings.ConnectionStrings.Payment));
            services.AddDbContextPool<LogContext>(options => options.UseSqlServer(settings.ConnectionStrings.Log));
            return services;
        }

        public static IServiceCollection AddCustomizedAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper();
            return services;
        }

        public static IServiceProvider Build(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            return services.BuildServiceProvider();
        }

        
    }
}
