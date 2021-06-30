using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CompanyToReturnDto>()
                .ForMember(d => d.Exchange, o => o.MapFrom(s => s.Exchange.Name))
                .ForMember(d => d.WebSite, o => o.MapFrom(s => s.Website == null ? string.Empty : s.Website));
        }
    }
}
