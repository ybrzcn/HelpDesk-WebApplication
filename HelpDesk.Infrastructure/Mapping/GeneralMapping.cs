using AutoMapper;
using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<SupportAgent, SupportAgentDto>().ReverseMap();
        }
    }
}
