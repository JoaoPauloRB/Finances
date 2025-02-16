using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using Service.Services.Interfaces;
using Service.Services;

namespace Application.Controllers
{
  public class UserController : Controller
  {
    private IUserService _service;
    private ITokenService _tokenService;
    public UserController(IUserService service, ITokenService tokenService) {
      _service = service;
      _tokenService = tokenService;
    }

    [HttpPost]
    [Route("/api/login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> LoginAsync([FromBody]User model)
    {
      var user = await _service.LoginAsync(model);
      return user == null
        ? BadRequest(new { message = "Usuário ou senha invalidos." })
        : Ok(new UserDto {
            Email = user.Email,
            Name = user.Name,
            UserId = user.UserId,
            Token = _tokenService.GenerateToken(user)
          });       
    }

    [HttpPost]
    [Route("/api/signup")]
    [AllowAnonymous]
    public ActionResult<dynamic> Signup([FromBody]User model)
    {
      _service.SignUp(model);      
      return Ok(new UserDto{
        Email = model.Email,
        Name = model.Name,
        UserId = model.UserId,
        Token = _tokenService.GenerateToken(model)
      });
    }

    [HttpGet]
    [Route("/api")]
    [AllowAnonymous]
    public ActionResult<dynamic> Teste()
    {     
      return "Working";
    }
  }
}