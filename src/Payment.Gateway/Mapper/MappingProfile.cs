using AutoMapper;
using Payment.Core.Domain.Transactions;
using Payment.Gateway.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Gateway.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region send order transaction mapping
            CreateMap<GatewaySendOrderRequestViewModel, GcoinSendOrderRequestViewModel>()
                .ForMember(des => des.TransRef, src => src.MapFrom(opts => $"BTC_{ Guid.NewGuid().ToString() }"));

            CreateMap<GcoinSendOrderResponseViewModel, GatewaySendOrderResponseViewModel>();

            CreateMap<Transaction, GcoinCheckSendOrderRequestViewModel>()
                .ForMember(des => des.SendOrderId, src => src.MapFrom(opts => opts.GcoinId))
                .ForMember(des => des.TransRef, src => src.MapFrom(opts => opts.Id));
            #endregion

            #region order transaction mapping
            CreateMap<GatewayOrderRequestViewModel, GcoinOrderRequestViewModel>()
                .ForMember(des => des.TransRef, src => src.MapFrom(opts => $"BTC_{ Guid.NewGuid().ToString() }"));

            CreateMap<GcoinOrderResponseViewModel, GatewayOrderResponseViewModel>();

            CreateMap<Transaction, GcoinCheckOrderRequestViewModel>()
                .ForMember(des => des.OrderId, src => src.MapFrom(opts => opts.GcoinId))
                .ForMember(des => des.TransRef, src => src.MapFrom(opts => opts.Id));
            #endregion

        }
    }
}
