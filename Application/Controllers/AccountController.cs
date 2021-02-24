using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using Service.Services.Interfaces;
using System;
using System.Security.Claims;

namespace Application.Controllers
{
  public class AccountController : Controller
  {
    private IAccountService _service;
    public AccountController(IAccountService service) {
      _service = service;
    }

    [HttpPost]
    [Route("/api/account")]
    [Authorize]
    public ActionResult<dynamic> Post([FromBody]Account model)
    {
      model.UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
      return Ok(_service.AddAccount(model));
    }

    [HttpGet]
    [Route("/api/account")]
    [Authorize]
    public ActionResult<dynamic> List()
    {
      return Ok(_service.ListAccounts());
    }
  }
}