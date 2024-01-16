using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_CountryStateCty.Models;
using WebAPI_CountryStateCty.Models.DTOs;
using WebAPI_CountryStateCty.Repository.IRepository;

namespace WebAPI_CountryStateCty.Controllers
{
  [Route("api/Country")]
  [ApiController]
  public class CountryController : ControllerBase
  {
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    public CountryController(ICountryRepository countryRepository,IMapper mapper)
    {
      _mapper = mapper;
      _countryRepository = countryRepository;          
    }
    [HttpGet]

    public IActionResult GetCountries()
    {
      var countryListDto = _countryRepository.GetCountries().
        ToList().Select(_mapper.Map<Country,CountryDto>);
      return Ok(countryListDto); 
    }
    [HttpGet("{countryId:int}")]

    public IActionResult GetCountry(int countryId)
    {
      var country = _countryRepository.GetCountry(countryId);
      if (country == null) return NotFound();
      var countryListDto = _mapper.Map<CountryDto>(country);
      return Ok(countryListDto); 
    }
    [HttpPost]

    public IActionResult CreateCountry([FromBody]CountryDto countryDto)
    {
      if (countryDto == null) return BadRequest(ModelState);
      if(!ModelState.IsValid) return BadRequest(); //400
      var country = _mapper.Map<CountryDto, Country>
        (countryDto);
      if(!_countryRepository.CreateCountry(country))
      {
        ModelState.AddModelError("",$"Something went wrong while save data : {country.Name}");
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
      return CreatedAtRoute("GetContry",
        new { countryId = country.Id },country);
    }

    

  }
}
