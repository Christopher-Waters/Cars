using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ModelYear, CarsToReturnDto>()
               .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
               .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
               .ForMember(d => d.Year, o => o.MapFrom(s => s.Year))
               .ForMember(d => d.Make, o => o.MapFrom(s => s.Makes.Name)).ReverseMap();

            CreateMap<ModelYear, CarsToInsertDto>()
               .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
               .ForMember(d => d.Year, o => o.MapFrom(s => s.Year))
               .ForMember(d => d.Make, o => o.MapFrom(s => s.Makes.Name)).ReverseMap();   


        }
    }
}