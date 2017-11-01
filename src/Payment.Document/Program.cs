using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Core.Configuration;
using Payment.Document.Extentions;
using Payment.Document.ViewModels;
using Payment.Service.Transactions;
using System;
using System.IO;
using System.Net.Http;

namespace Payment.Document
{
    public class Program
    {
        private static IConfiguration _configuration;
        private static IServiceCollection _services;
        private static IServiceProvider _providers;
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            _services = services.ConfigureServices(_configuration);
            _providers = _services.BuildServiceProvider();
            var b = _providers.GetService<ITransactionService>();

            //GcoinSendOrderRequestViewModel request = new GcoinSendOrderRequestViewModel
            //{
            //    TransRef = Guid.NewGuid().ToString(),
            //    Amount = 1000,
            //    UserNophone = "+841243455567",
            //    CallbackData = "test_call_back",
            //    UserId = "", 
            //    ServiceId = ""
            //};
            //HttpResponseMessage reponse = GcoinExtentions.SendGcoin<GcoinSendOrderRequestViewModel>("/gateway/send_order?", request);
        }
    }
}
