using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Gateway.ViewModels;
using Payment.Service.Transactions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Payment.Common;
using System.Net.Http;
using Payment.Gateway.Extentions;
using Newtonsoft.Json;
using Payment.Core.Domain.Transactions;
using Payment.Common.Enums;

namespace Payment.Gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/order")]
    public class OrderController : PaymentController
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ITransactionService transactionService, IMapper mapper, ILogger<OrderController> logger)
        {
            _transactionService = transactionService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create(GatewayOrderRequestViewModel requestViewModel)
        {
            try
            {
                _logger.LogDebug("----------Begin create [ORDER] transaction----------");
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
                    var gcoinOrderRequestViewModel = _mapper.Map<GatewayOrderRequestViewModel, GcoinOrderRequestViewModel>(requestViewModel);

                    //send to gcoin
                    HttpResponseMessage gCoinResponse = GcoinExtentions.SendGcoin<GcoinOrderRequestViewModel>("/gateway/order?", gcoinOrderRequestViewModel);
                    var gCoinResponseContent = gCoinResponse.Content.ReadAsStringAsync().Result;
                    _logger.LogDebug($"Request gcoin: {gCoinResponse.RequestMessage.RequestUri}");
                    if (gCoinResponse.IsSuccessStatusCode)
                    {
                        _logger.LogDebug($"Response gcoin successed: {gCoinResponseContent}");
                        var gCoinResponseObject = JsonConvert.DeserializeObject<GcoinOrderResponseViewModel>(gCoinResponseContent);
                        //save to transaction table
                        var transaction = new Transaction
                        {
                            Id = gcoinOrderRequestViewModel.TransRef,
                            BcoinId = requestViewModel.TransRef,
                            GcoinId = gCoinResponseObject.OrderId,
                            Status = (int)TransactionStatus.Successed,
                            Result = gCoinResponseContent
                        };
                        _transactionService.Add(transaction);
                        _logger.LogDebug($"Inserted transaction: {transaction.Id}");
                        //save to order-transction table
                        var orderTransaction = new OrderTransaction
                        {
                            Id = gCoinResponseObject.OrderId,
                            Address = gCoinResponseObject.Address,
                            AmountRequested = gCoinResponseObject.AmountRequested,
                            Amount = gCoinResponseObject.Amount,
                            CreatedOn = gCoinResponseObject.CreatedOn,
                            Time = gCoinResponseObject.Time,
                            Status = gCoinResponseObject.Status
                        };
                        _transactionService.Order.Add(orderTransaction);
                        _logger.LogDebug($"Inserted order transaction: {orderTransaction.Id}");
                        //return to partner
                        var bCoinResponseObject = _mapper.Map<GcoinOrderResponseViewModel, GatewayOrderResponseViewModel>(gCoinResponseObject);
                        bCoinResponseObject.OrderId = transaction.Id;
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            finally
            {
                _logger.LogDebug("----------End create [ORDER] transaction----------");
            }
        }

        [HttpGet]
        [Route("check")]
        public IActionResult Check(GatewayCheckOrderRequestViewModel requestViewModel)
        {
            try
            {
                _logger.LogDebug("----------Begin check [Order]----------");
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.GetErrors();
                    _logger.LogDebug($"Validate modal failed ! : {string.Join(", ", errors)}");
                    return BadRequest(new GatewayErrorViewmodel(errors));
                }
                //get from db by bcoin id
                var transaction = _transactionService.GetByIdOrBcoinId(requestViewModel.OrderId, requestViewModel.TransRef);
                if (transaction == null)
                {
                    _logger.LogDebug($"Transaction: Id={requestViewModel.OrderId} - BcoinId={requestViewModel.TransRef} not found !");
                    return NotFound(new GatewayErrorViewmodel("Transaction not found"));
                }
                //mapping object check gcoin
                var gcoinCheckOrderRequestViewModel = _mapper.Map<Transaction, GcoinCheckOrderRequestViewModel>(transaction);
                HttpResponseMessage gCoinResponse = GcoinExtentions.SendGcoin<GcoinCheckOrderRequestViewModel>("/gateway/check_order?", gcoinCheckOrderRequestViewModel);
                var gCoinResponseContent = gCoinResponse.Content.ReadAsStringAsync().Result;
                _logger.LogDebug($"Request gcoin: {gCoinResponse.RequestMessage.RequestUri}");
                if (gCoinResponse.IsSuccessStatusCode)
                {
                    _logger.LogDebug($"Reponse check gcoin success: {gCoinResponseContent}");
                    var gCoinResponseObject = JsonConvert.DeserializeObject<GcoinOrderResponseViewModel>(gCoinResponseContent);
                    //mapping to return partner
                    var bCoinResponseObject = _mapper.Map<GcoinOrderResponseViewModel, GatewayOrderResponseViewModel>(gCoinResponseObject);
                    bCoinResponseObject.OrderId = transaction.Id;
                    return Ok(bCoinResponseObject);
                }
                else
                {
                    _logger.LogDebug($"Reponse check gcoin error: {gCoinResponseContent}");
                    return BadRequest(new GatewayErrorViewmodel("Gcoin check error"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            finally
            {
                _logger.LogDebug("----------Begin check [Order]----------");
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