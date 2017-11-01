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
using Payment.Common.Enums;
using Newtonsoft.Json;
using Payment.Common;
using Payment.Core.Domain.Payment;
using Payment.Gateway.Filters;

namespace Payment.Gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/sendorder")]
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
        [ProducesResponseType(typeof(GatewaySendOrderResponseViewModel), 200)]
        public IActionResult Create(GatewaySendOrderRequestViewModel requestViewModel)
        {
            try
            {
                _logger.LogDebug("----------Begin create [SEND ORDER] transaction----------");
                //validate model
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.GetErrors();
                    _logger.LogDebug($"Validate modal failed ! : {string.Join(", ", errors)}");
                    return BadRequest(new GatewayErrorViewmodel(errors));
                }
                
                //check exist transaction 
                if (!_transactionService.IsExistBcoinId(requestViewModel.TransRef))
                {
                    //mapping object send to gcoin
                    var gcoinSendOrderRequestViewModel = _mapper.Map<GatewaySendOrderRequestViewModel, GcoinSendOrderRequestViewModel>(requestViewModel);
                   
                    //send to gcoin
                    HttpResponseMessage gCoinResponse = GcoinExtentions.SendGcoin<GcoinSendOrderRequestViewModel>("/gateway/send_order?", gcoinSendOrderRequestViewModel);
                    var gCoinResponseContent = gCoinResponse.Content.ReadAsStringAsync().Result;
                    _logger.LogDebug($"Request gcoin: {gCoinResponse.RequestMessage.RequestUri}");
                    if (gCoinResponse.IsSuccessStatusCode)
                    {
                        _logger.LogDebug($"Response gcoin successed: {gCoinResponseContent}");
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
                        _logger.LogDebug($"Inserted transaction: {transaction.Id}");
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
                        _logger.LogDebug($"Inserted send order transaction: {sendOrderTransaction.Id}");
                        //return to partner
                        var bCoinResponseObject = _mapper.Map<GcoinSendOrderResponseViewModel, GatewaySendOrderResponseViewModel>(gCoinResponseObject);
                        bCoinResponseObject.SendOrderId = transaction.Id;
                        return Ok(bCoinResponseObject);
                    }
                    else
                    {
                        _logger.LogDebug($"Response gcoin not success: {gCoinResponseContent}");
                        var gCoinReponseError = JsonConvert.DeserializeObject<GcoinErrorViewModel>(gCoinResponseContent);
                        return BadRequest(new GatewayErrorViewmodel(gCoinReponseError.Error));
                    }
                }
                else
                {
                    _logger.LogDebug($"Exist transaction with key bcoin : {requestViewModel.TransRef}");
                    return BadRequest(new GatewayErrorViewmodel("Exist Transaction"));
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            finally
            {
                _logger.LogDebug("----------End create [SEND ORDER] transaction----------");
            }
        }

        [HttpGet]
        [Route("check")]
        public IActionResult Check(GatewayCheckSendOrderRequestViewModel requestViewModel)
        {
            
            try
            {
                _logger.LogDebug("----------Begin check [Send Order]----------");
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.GetErrors();
                    _logger.LogDebug($"Validate modal failed ! : {string.Join(", ", errors)}");
                    return BadRequest(new GatewayErrorViewmodel(errors));
                }
                //get from db by bcoin id
                var transaction = _transactionService.GetByIdOrBcoinId(requestViewModel.SendOrderId, requestViewModel.TransRef);
                if(transaction == null)
                {
                    _logger.LogDebug($"Transaction: Id={requestViewModel.SendOrderId} - BcoinId={requestViewModel.TransRef} not found !");
                    return NotFound(new GatewayErrorViewmodel("Transaction not found"));
                }
                //mapping object check gcoin
                var gcoinCheckSendOrderRequestViewModel = _mapper.Map<Transaction, GcoinCheckSendOrderRequestViewModel>(transaction);
                HttpResponseMessage gCoinResponse = GcoinExtentions.SendGcoin<GcoinCheckSendOrderRequestViewModel>("/gateway/check_send_order?", gcoinCheckSendOrderRequestViewModel);
                var gCoinResponseContent = gCoinResponse.Content.ReadAsStringAsync().Result;
                _logger.LogDebug($"Request gcoin: {gCoinResponse.RequestMessage.RequestUri}");
                if (gCoinResponse.IsSuccessStatusCode)
                {
                    _logger.LogDebug($"Reponse check gcoin success: {gCoinResponseContent}");
                    var gCoinResponseObject = JsonConvert.DeserializeObject<GcoinSendOrderResponseViewModel>(gCoinResponseContent);
                    //mapping to return partner
                    var bCoinResponseObject = _mapper.Map<GcoinSendOrderResponseViewModel, GatewaySendOrderResponseViewModel>(gCoinResponseObject);
                    bCoinResponseObject.SendOrderId = transaction.Id;
                    return Ok(bCoinResponseObject);
                }
                else
                {
                    _logger.LogDebug($"Reponse check gcoin error: {gCoinResponseContent}");
                    return BadRequest(new GatewayErrorViewmodel("Gcoin check error"));
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            finally
            {
                _logger.LogDebug("----------Begin check [Send Order]----------");
            }
        }

        [HttpGet]
        [Route("history")]
        public IActionResult History()
        {
            return null;
        }
    }
}