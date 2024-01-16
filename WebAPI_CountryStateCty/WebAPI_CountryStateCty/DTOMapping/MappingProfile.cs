using AutoMapper;
using WebAPI_CountryStateCty.Models;
using WebAPI_CountryStateCty.Models.DTOs;

namespace WebAPI_CountryStateCty.DTOMapping
{
  public class MappingProfile:Profile
  {
    public MappingProfile()
    {
        CreateMap<Country,CountryDto>().ReverseMap();
      CreateMap<State,StateDto>().ReverseMap();
      CreateMap<City,CityDto>().ReverseMap();
      CreateMap<Register, RegisterDto>().ReverseMap();    
    }
  }
}
