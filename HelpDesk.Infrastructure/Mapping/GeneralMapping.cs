using AutoMapper;
using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash)).ReverseMap();
            
            CreateMap<SupportAgent, SupportAgentDto>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash)).ReverseMap();
        }
    }
}
