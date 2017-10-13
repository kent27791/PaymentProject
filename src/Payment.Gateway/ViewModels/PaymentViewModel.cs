using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Gateway.ViewModels
{
    public class GcoinPaymentRequestViewModel
    {
        /// <summary>
        /// Dùng để xác thực, được tạo qua các bước sau: + Tạo string (định dạng utf-8): $nophone + “:” + $noapi, nghĩa là nối string số điện thoại (id của Merchant) cộng với kí tự “:” cộng với string là tham số noapi của Merchant + Chuyển sang định dạng base64
        /// </summary>
        [JsonProperty("auth")]
        public string Auth { get; set; }

        /// <summary>
        /// Là thời điểm hiện tại dưới dạng Unix time - số giây tính từ Jan 01 1970. (UTC) - để kiểm tra về mặt thời gian.
        /// </summary>
        [JsonProperty("nonce")]
        public int Nonce { get; set; }

        /// <summary>
        /// Dùng cho lớp xác thực thứ hai, được tính qua các bước như sau: + $nonce dưới dạng string được hash bằng sha256 để có kết quả được biểu diễn ở định dạng base64
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}
