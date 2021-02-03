using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using Infra.Data;
using Service.Services;

namespace Application.Controllers
{
  public class AccountController : Controller
  {
    private readonly UnitOfWork _uow;
    private AccountService _service;
    public AccountController(UnitOfWork uow) {
      _uow = uow;
      _service = new AccountService(_uow);
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