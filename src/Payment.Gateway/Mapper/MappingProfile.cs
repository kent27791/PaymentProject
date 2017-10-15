using AutoMapper;
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
            CreateMap<GatewaySendOrderRequestViewModel, GcoinSendOrderRequestViewModel>()
                .ForMember(des => des.TransRef, src => src.MapFrom(opts => $"BTC_{ Guid.NewGuid().ToString() }"));
            CreateMap<GcoinSendOrderResponseViewModel, GatewaySendOrderResponseViewModel>();
        }
    }
}
