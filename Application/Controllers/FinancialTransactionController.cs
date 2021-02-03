using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using Infra.Data;

namespace Application.Controllers
{
  public class FinancialTransactionController : Controller
  {
    private readonly UnitOfWork _uow;
    public FinancialTransactionController(UnitOfWork uow) {
      _uow = uow;
    }

    [HttpPost]
    [Route("/transaction")]
    [AllowAnonymous]
    public ActionResult<dynamic> Post([FromBody]FinancialTransaction model)
    {
      _uow.FinancialTransactionRepository.Insert(model);
      _uow.Save();      
      return Ok(model);
    }
  }
}