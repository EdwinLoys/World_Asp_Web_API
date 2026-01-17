using AutoMapper;
using WorldApi.Data;
using WorldApi.DTO.Country;
using WorldApi.Models;

namespace WorldApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Sources to Destination
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();
        }
    }
}
