using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using Infra.Data;

namespace Application.Controllers
{
  public class AccountController : Controller
  {
    private readonly UnitOfWork _uow;
    public AccountController(UnitOfWork uow) {
      _uow = uow;
    }

    [HttpPost]
    [Route("/account")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Post([FromBody]Account model)
    {
      _uow.AccountRepository.Insert(model);
      _uow.Save();      
      return Ok(model);
    }

    [HttpGet]
    [Route("/account")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> List()
    {
      return Ok(_uow.AccountRepository.Get());
    }
  }
}