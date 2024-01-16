using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_CountryStateCty.Models;
using WebAPI_CountryStateCty.Models.DTOs;
using WebAPI_CountryStateCty.Repository.IRepository;

namespace WebAPI_CountryStateCty.Controllers
{
  [Route("api/State")]
  [ApiController]
  public class StateController : ControllerBase
  {
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;
    public StateController(IStateRepository stateRepository,
      IMapper mapper)
    {
      _mapper = mapper;
      _stateRepository = stateRepository;          
    }
    [HttpGet]

    public IActionResult GetStates()
    {
      var stateListDto = _stateRepository.GetStates().
        ToList().Select(_mapper.Map<State,StateDto>);
      return Ok(stateListDto);
    }
    [HttpGet("{stateId:int}")]

    public IActionResult GetState(int stateId)
    {
      var state = _stateRepository.GetState(stateId);
      if (state == null) return NotFound();
      var stateDto = _mapper.Map<StateDto>(state);
      return Ok(stateDto);
    }
    [HttpPost]

    public IActionResult CreateState([FromBody]StateDto stateDto)
    {
      if(stateDto == null) return BadRequest(ModelState);
      if(!ModelState.IsValid) return BadRequest();
      var state = _mapper.Map<StateDto,State>(stateDto);
      if(!_stateRepository.CreateState(state))
      {
        ModelState.AddModelError("", $"Something went wrong while save data:{state.Name}");
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
      return CreatedAtRoute("GetState", new { stateId = state.Id }, state);
    }
  }
}
