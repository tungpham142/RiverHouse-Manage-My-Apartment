using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RiverHouse.Dtos;
using RiverHouse.Models;

namespace RiverHouse.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Member, MemberDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Event, NewEventDto>();

            Mapper.CreateMap<MemberDto, Member>().ForMember(c => c.Id, opt => opt.Ignore());
            //Mapper.CreateMap<PaymentDto, Payment>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}