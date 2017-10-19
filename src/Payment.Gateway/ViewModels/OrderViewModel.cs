using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Gateway.ViewModels
{
    #region Gcoin
    public class GcoinOrderRequestViewModel
    {
        /// <summary>
        /// Mã của giao dịch trong hệ thống của Merchant, gửi lên để phục vụ đối soát
        /// </summary>
        [FromQuery(Name = "transRef")]
        public string TransRef { get; set; }

        /// <summary>
        /// Số gCoin tương ứng User muốn nạp để đổi lấy Xu
        /// </summary>
        [FromQuery(Name = "amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Dữ liệu Merchant muốn gửi lên để lưu ở hệ thống gCoin Platform cùng với giao dịch. String này cần đảm bảo định dạng query trên url
        /// </summary>
        [FromQuery(Name = "callbackData")]
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

        /// <summary>
        /// Không bắt buộc, gửi lên để phục vụ tra cứu đối soát
        /// </summary>
        [FromQuery(Name = "userNophone")]
        public string UserNophone { get; set; }
    }

    public class GcoinOrderResponseViewModel
    {
        /// <summary>
        /// Địa chỉ đích đưa cho User để User chuyển gCoin vào
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Id của giao dịch tạo bởi hệ thống gCoin Platform
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// Lượng gCoin đề nghị (như $amount gửi lên)
        /// </summary>
        [JsonProperty("amountRequested")]
        public int AmountRequested { get; set; }

        /// <summary>
        /// Lượng gCoin thực nhận từ khách hàng, có giá trị -1 khi giao dịch chưa được thưc hiện
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Thời gian lúc khởi tạo giao dịch (Unix time)
        /// </summary>
        [JsonProperty("createdOn")]
        public int CreatedOn { get; set; }

        /// <summary>
        /// Thời gian lúc phát sinh giao dịch (Unix time)
        /// </summary>
        [JsonProperty("time")]
        public int? Time { get; set; }

        /// <summary>
        /// Trạng thái, có thể mang các giá trị: 0: Chưa làm gì 1: Gửi đúng số gCoin, amount = amountRequested 2: Gửi thừa, amount > amountRequested 3: Gửi thiếu, amount < amountRequested
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }
    }

    public class GcoinCheckOrderRequestViewModel
    {
        [FromQuery(Name = "transRef")]
        public string TransRef { get; set; }

        [FromQuery(Name = "orderId")]
        public string OrderId { get; set; }
    }
    #endregion

    #region Gateway
    public class GatewayOrderRequestViewModel
    {
        /// <summary>
        /// Mã của giao dịch trong hệ thống của Merchant, gửi lên để phục vụ đối soát
        /// </summary>
        [FromQuery(Name = "trans_ref"), Required]
        public string TransRef { get; set; }

        /// <summary>
        /// Số gCoin tương ứng User muốn nạp để đổi lấy Xu
        /// </summary>
        [FromQuery(Name = "amount"), Required]
        public int Amount { get; set; }

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

        /// <summary>
        /// Không bắt buộc, gửi lên để phục vụ tra cứu đối soát
        /// </summary>
        [FromQuery(Name = "user_nophone")]
        public string UserNophone { get; set; }
    }

    public class GatewayOrderResponseViewModel
    {
        /// <summary>
        /// Địa chỉ đích đưa cho User để User chuyển gCoin vào
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Id của giao dịch tạo bởi hệ thống gCoin Platform
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// Lượng gCoin đề nghị (như $amount gửi lên)
        /// </summary>
        [JsonProperty("amount_requested")]
        public int AmountRequested { get; set; }

        /// <summary>
        /// Lượng gCoin thực nhận từ khách hàng, có giá trị -1 khi giao dịch chưa được thưc hiện
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Thời gian lúc khởi tạo giao dịch (Unix time)
        /// </summary>
        [JsonProperty("created_on")]
        public int CreatedOn { get; set; }

        /// <summary>
        /// Thời gian lúc phát sinh giao dịch (Unix time)
        /// </summary>
        [JsonProperty("time")]
        public int? Time { get; set; }

        /// <summary>
        /// Trạng thái, có thể mang các giá trị: 0: Chưa làm gì 1: Gửi đúng số gCoin, amount = amountRequested 2: Gửi thừa, amount > amountRequested 3: Gửi thiếu, amount < amountRequested
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }
    }

    public class GatewayCheckOrderRequestViewModel
    {
        [FromQuery(Name = "trans_ref")]
        public string TransRef { get; set; }

        [FromQuery(Name = "order_id")]
        public string OrderId { get; set; }
    }
    #endregion
}
