using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using Service.Services.Interfaces;

namespace Application.Controllers
{
  public class AccountController : Controller
  {
    private IAccountService _service;
    public AccountController(IAccountService service) {
      _service = service;
    }

    [HttpPost]
    [Route("/account")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Post([FromBody]Account model)
    {
      return Ok(_service.AddAccount(model));
    }

    [HttpGet]
    [Route("/account")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> List()
    {
      return Ok(_service.ListAccounts());
    }
  }
}