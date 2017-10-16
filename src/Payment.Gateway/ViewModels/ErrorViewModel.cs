using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Gateway.ViewModels
{
    public class GcoinErrorViewModel
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }
    public class GatewayErrorViewmodel
    {
        public GatewayErrorViewmodel()
        {
            Errors = new List<string>();
        }
        public GatewayErrorViewmodel(string error) : this()
        {
            Errors.Add(error);
        }
        public GatewayErrorViewmodel(params string[] errors) : this()
        {
            Errors.AddRange(errors.ToList());
        }
        public GatewayErrorViewmodel(List<string> errors) : this()
        {
            Errors.AddRange(errors);
        }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }
    }
}
