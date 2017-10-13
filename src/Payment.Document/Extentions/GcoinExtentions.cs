using Payment.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Payment.Document.Extentions
{
    public static class GcoinExtentions
    {
        public static readonly string GCOIN_MERCHANT_NOPHONE = "+84908755721";
        public static readonly string GCOIN_MERCHANT_NOAPI = "05d1a7d3-dc65-4b38-9561-0324ba204fa8";
        public static readonly string GCOIN_MERCHANT_SECRETKEY = "c52622d6-95f4-43c4-a288-5577839de0af";
        public static readonly string GCOIN_DOMAIN = "http://tmapi.vngCoin.com";
        public static HttpResponseMessage SendGcoin<T>(string path, T obj)
        {
            string queryString = StringHelper.ConvertObjectToQueryString<T>(obj);
            string auth = SecurityHelper.GetBase64Encode(GCOIN_MERCHANT_NOPHONE + ":" + GCOIN_MERCHANT_NOAPI);//SecurityHelper.GetBase64Encode($"{GCOIN_MERCHANT_NOPHONE}:{GCOIN_MERCHANT_NOAPI}");
            string nonce = ((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString();
            string signature = SecurityHelper.GetHash_HMAC_SHA512(GCOIN_MERCHANT_SECRETKEY, string.Format("{0}{1}{2}", path, queryString, SecurityHelper.GetHash_SHA256(nonce)));//SecurityHelper.GetHash_HMAC_SHA512(GCOIN_MERCHANT_SECRETKEY, $"{path}{queryString}{SecurityHelper.GetHash_SHA256(nonce)}");

            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri($"{GCOIN_DOMAIN}{path}{queryString}");
            request.Headers.TryAddWithoutValidation("Authorization", auth); //it's not true for technology.
            request.Headers.Add("X-Nonce", nonce);
            request.Headers.Add("X-Signature", signature);
            HttpClient client = new HttpClient();
            return client.SendAsync(request).Result;
        }
    }
}
