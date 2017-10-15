using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Gateway.ViewModels;
using Payment.Gateway.Extentions;
using System.Net.Http;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Payment.Service.Transactions;
using Payment.Core.Domain.Transactions;
using Payment.Common.Enums;
using Newtonsoft.Json;

namespace Payment.Gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/sendorder")]
    //[GatewayMerchant]
    public class SendOrderController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
        private readonly ILogger<SendOrderController> _logger;
        public SendOrderController(ITransactionService transactionService, IMapper mapper, ILogger<SendOrderController> logger)
        {
            _transactionService = transactionService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create(GatewaySendOrderRequestViewModel requestViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //check exist 
                if (!_transactionService.IsExistBcoinId(requestViewModel.TransRef))
                {
                    //mapper to object gcoin
                    var gcoinSendOrderRequestViewModel = _mapper.Map<GatewaySendOrderRequestViewModel, GcoinSendOrderRequestViewModel>(requestViewModel);
                    //send to gcoin
                    HttpResponseMessage gCoinResponse = GcoinExtentions.SendGcoin<GcoinSendOrderRequestViewModel>("/gateway/send_order?", gcoinSendOrderRequestViewModel);
                    var gCoinResponseContent = gCoinResponse.Content.ReadAsStringAsync().Result;
                    if (gCoinResponse.IsSuccessStatusCode)
                    {
                        var gCoinResponseObject = JsonConvert.DeserializeObject<GcoinSendOrderResponseViewModel>(gCoinResponseContent);
                        //save to transaction table
                        var transaction = new Transaction
                        {
                            Id = gcoinSendOrderRequestViewModel.TransRef,
                            BcoinId = requestViewModel.TransRef,
                            GcoinId = gCoinResponseObject.SendOrderId,
                            Status = (int)TransactionStatus.Successed,
                            Result = gCoinResponseContent
                        };
                        _transactionService.Add(transaction);
                        //save to order-transction table
                        var sendOrderTransaction = new SendOrderTransaction
                        {
                            Id = gCoinResponseObject.SendOrderId,
                            UserNophone = gCoinResponseObject.UserNophone,
                            Address = gCoinResponseObject.Address,
                            Amount = gCoinResponseObject.Amount,
                            CreatedOn = gCoinResponseObject.CreatedOn,
                            Time = gCoinResponseObject.Time,
                            Status = gCoinResponseObject.Status
                        };
                        _transactionService.SendOrder.Add(sendOrderTransaction);
                        //return to partner
                        var bCoinResponseObject = _mapper.Map<GcoinSendOrderResponseViewModel, GatewaySendOrderResponseViewModel>(gCoinResponseObject);
                        bCoinResponseObject.SendOrderId = transaction.Id;
                        return Ok(bCoinResponseObject);
                    }
                    else
                    {
                        return BadRequest(gCoinResponseContent);
                    }
                }
                else
                {
                    return BadRequest("TRANSACTION_EXIST");
                }

                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("check")]
        public IActionResult Check()
        {
            return null;
        }

        [HttpGet]
        [Route("history")]
        public IActionResult History()
        {
            return null;
        }
    }
}