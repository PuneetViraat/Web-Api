using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_CountryStateCty.Models;
using WebAPI_CountryStateCty.Models.DTOs;
using WebAPI_CountryStateCty.Repository.IRepository;

namespace WebAPI_CountryStateCty.Controllers
{
  [Route("api/City")]
  [ApiController]
  public class CityController : ControllerBase
  {
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    public CityController(ICityRepository cityRepository,
      IMapper mapper)
    {
      _mapper = mapper;
      _cityRepository = cityRepository;          
    }
    [HttpGet]
    public IActionResult GetCities()
    {
      var cityListDto = _cityRepository.GetCities().
        ToList().Select(_mapper.Map<City, CityDto>);
      return Ok(cityListDto);
    }
    [HttpGet("{cityId:int}")]

    public IActionResult GetCity(int cityId)
    {
      var city = _cityRepository.GetCity(cityId);
      if (city == null) return NotFound();
      var cityDto = _mapper.Map<CityDto>(city);
      return Ok(cityDto);      
    }
    [HttpPost]

    public IActionResult CreateCity([FromBody]CityDto cityDto)
    {
      if (cityDto == null) return BadRequest(ModelState);
      if(!ModelState.IsValid) return BadRequest();
      var city = _mapper.Map<CityDto, City>(cityDto);
      if(!_cityRepository.CreateCity(city))
      {
        ModelState.AddModelError("",$"Something went wrong while save data :{city.Name}");
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
      return CreatedAtRoute("GetCity", new { cityId = city.Id }, city);

    }
  }
}
