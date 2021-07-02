using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(d => d.Exchange, o => o.MapFrom(s => s.Exchange.Name))
                .ForMember(d => d.WebSite, o => o.MapFrom(s => s.Website == null ? string.Empty : s.Website));
            CreateMap<CompanyDto, Company>()
                .ForPath(d => d.Exchange.Name, o => o.MapFrom(s => s.Exchange))
                .ForPath(d => d.Exchange.Id, o => o.MapFrom(s => s.ExchangeId));
        }
    }
}
