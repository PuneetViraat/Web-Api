using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_CountryStateCty.Models;
using WebAPI_CountryStateCty.Models.DTOs;
using WebAPI_CountryStateCty.Repository.IRepository;

namespace WebAPI_CountryStateCty.Controllers
{
  [Route("api/Register")]
  [ApiController]
  public class RegisterController : ControllerBase
  {
    private readonly IRegisterRepository _registerRepository;
    private readonly IMapper _mapper;
    public RegisterController(IRegisterRepository registerRepository,
      IMapper mapper)
    {
      _mapper = mapper;
      _registerRepository = registerRepository;          
    }
    [HttpGet]

    public IActionResult GetRegisters()
    {
      var registerListDto = _registerRepository.GetRegisters().
        ToList().Select(_mapper.Map<Register,RegisterDto>);
      return Ok(registerListDto);
    }
    [HttpGet("{registerId:int}")]
    public IActionResult GetRegister(int registerId)
    {
      var register = _registerRepository.GetRegister(registerId);
      if (register == null) return NotFound();
      var registerDto = _mapper.Map<RegisterDto>(register);
      return Ok(registerDto);
    }
    [HttpPost]
    public IActionResult CreateRegister([FromBody]RegisterDto registerDto)
    {
      if (registerDto == null) return BadRequest(ModelState);
      if(!ModelState.IsValid) return BadRequest();
      var register = _mapper.Map<RegisterDto, Register>(registerDto);
      if(!_registerRepository.CreateRegister(register))
      {
        ModelState.AddModelError("", $"Something went wrong while save data");
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
      return CreatedAtRoute("GetRegister", new { registerId = register.Id }, register);
      
    }
    [HttpPut]

    public IActionResult UpdateRegister([FromBody]RegisterDto registerDto)
    {
      if (registerDto == null) return BadRequest();
      if (!ModelState.IsValid) return BadRequest();
      var register = _mapper.Map<Register>(registerDto);
      if(!_registerRepository.UpdateRegister(register))
      {
        ModelState.AddModelError("", $"Something went wrong while update data : {register.Name}");
        return StatusCode(StatusCodes.Status500InternalServerError );
      }
      return NoContent();
    }
    [HttpDelete]

    public IActionResult DeleteRegister(int registerId)
    {
      var register = _registerRepository.GetRegister(registerId);
      if (register == null) return NotFound();
      if(!_registerRepository.DeleteRegister(register))
      {
        ModelState.AddModelError("", $"Something went wrong while delete data :{register.Name}");
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
      return Ok();
    }
  }
}
