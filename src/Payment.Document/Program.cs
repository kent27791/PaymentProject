using Payment.Document.Extentions;
using Payment.Document.ViewModels;
using System;
using System.Net.Http;

namespace Payment.Document
{
    class Program
    {
        static void Main(string[] args)
        {
            GcoinSendOrderRequestViewModel request = new GcoinSendOrderRequestViewModel
            {
                TransRef = Guid.NewGuid().ToString(),
                Amount = 1000,
                UserNophone = "+841243455567",
                CallbackData = "test_call_back",
                UserId = "", 
                ServiceId = ""
            };
            HttpResponseMessage reponse = GcoinExtentions.SendGcoin<GcoinSendOrderRequestViewModel>("/gateway/send_order?", request);
        }
    }
}
