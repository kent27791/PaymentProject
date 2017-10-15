using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Gateway.ViewModels
{
    public class GcoinSendOrderRequestViewModel
    {
        /// <summary>
        /// Mã của giao dịch trong hệ thống của Merchant (gửi lên để đối soát về sau)
        /// </summary>
        [FromQuery(Name = "transRef")]
        public string TransRef { get; set; }

        /// <summary>
        /// Số gCoin tương ứng User muốn rút
        /// </summary>
        [FromQuery(Name = "amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Định danh ví của User, dưới dạng số điện thoại. Chú ý là phải bắt đầu bằng '+84' nhưng do query trên url nên kí tự '+' được thể hiện là '%2B' CHÚ Ý: Khác với các hàm tạo giao dịch khác, tham số này là bắt buộc.
        /// </summary>
        [FromQuery(Name = "userNophone")]
        public string UserNophone { get; set; }

        /// <summary>
        /// Dữ liệu Merchant muốn gửi lên để lưu ở hệ thống gCoin Platform cùng với giao dịch. String này cần đảm bảo định dạng query trên url
        /// </summary>
        [FromQuery(Name = "callback_data")]
        public string CallbackData { get; set; }

        /// <summary>
        /// Không bắt buộc, gửi lên để phục vụ tra cứu đối soát
        /// </summary>
        [FromQuery(Name = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Không bắt buộc, gửi lên để phục vụ tra cứu đối soát
        /// </summary>
        [FromQuery(Name = "serviceId")]
        public string ServiceId { get; set; }
    }

    public class GcoinSendOrderResponseViewModel
    {
        /// <summary>
        /// Id của giao dịch tạo bởi hệ thống gCoin Platform
        /// </summary>
        [JsonProperty("sendOrderId")]
        public string SendOrderId { get; set; }

        /// <summary>
        /// Số điện thoại của User nhận gCoin
        /// </summary>
        [JsonProperty("userNophone")]
        public string UserNophone { get; set; }

        /// <summary>
        /// Lượng gCoin gửi đi
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Địa chỉ đích nhận gCoin của khách hàng
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Thời gian lúc khởi tạo giao dịch (Unix time)
        /// </summary>
        [JsonProperty("createdOn")]
        public int CreatedOn { get; set; }

        /// <summary>
        /// Thời gian lúc phát sinh giao dịch (Unix time)
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }

        /// <summary>
        /// Trạng thái, có thể mang các giá trị: 0: Chưa làm gì 1: Chuyển gCoin thành công 2: Chuyển gCoin thất bại, lý do không đủ tiền ở tài khoản 3: Chuyển gCoin thất bại, lý do khác 4: Chuyển gCoin thất bại, lý do tài khoản bị tạm khóa
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }
    }

    public class GatewaySendOrderRequestViewModel
    {
        /// <summary>
        /// Mã của giao dịch trong hệ thống của Merchant (gửi lên để đối soát về sau)
        /// </summary>
        [FromQuery(Name = "trans_ref")]
        [Required]
        public string TransRef { get; set; }

        /// <summary>
        /// Số gCoin tương ứng User muốn rút
        /// </summary>
        [FromQuery(Name = "amount")]
        [Required]
        public int Amount { get; set; }

        /// <summary>
        /// Định danh ví của User, dưới dạng số điện thoại. Chú ý là phải bắt đầu bằng '+84' nhưng do query trên url nên kí tự '+' được thể hiện là '%2B' CHÚ Ý: Khác với các hàm tạo giao dịch khác, tham số này là bắt buộc.
        /// </summary>
        [FromQuery(Name = "user_nophone")]
        [Required]
        public string UserNophone { get; set; }

        /// <summary>
        /// Dữ liệu Merchant muốn gửi lên để lưu ở hệ thống gCoin Platform cùng với giao dịch. String này cần đảm bảo định dạng query trên url
        /// </summary>
        [FromQuery(Name = "callback_data")]
        public string CallbackData { get; set; }

        /// <summary>
        /// Không bắt buộc, gửi lên để phục vụ tra cứu đối soát
        /// </summary>
        [FromQuery(Name = "user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Không bắt buộc, gửi lên để phục vụ tra cứu đối soát
        /// </summary>
        [FromQuery(Name = "service_id")]
        public string ServiceId { get; set; }
    }

    public class GatewaySendOrderResponseViewModel
    {
        /// <summary>
        /// Id của giao dịch tạo bởi hệ thống gCoin Platform
        /// </summary>
        [JsonProperty("send_order_id")]
        public string SendOrderId { get; set; }

        /// <summary>
        /// Số điện thoại của User nhận gCoin
        /// </summary>
        [JsonProperty("user_nophone")]
        public string UserNophone { get; set; }

        /// <summary>
        /// Lượng gCoin gửi đi
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Địa chỉ đích nhận gCoin của khách hàng
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Thời gian lúc khởi tạo giao dịch (Unix time)
        /// </summary>
        [JsonProperty("created_on")]
        public int CreatedOn { get; set; }

        /// <summary>
        /// Thời gian lúc phát sinh giao dịch (Unix time)
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }

        /// <summary>
        /// Trạng thái, có thể mang các giá trị: 0: Chưa làm gì 1: Chuyển gCoin thành công 2: Chuyển gCoin thất bại, lý do không đủ tiền ở tài khoản 3: Chuyển gCoin thất bại, lý do khác 4: Chuyển gCoin thất bại, lý do tài khoản bị tạm khóa
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
