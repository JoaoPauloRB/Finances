using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using Service.Services.Interfaces;
using Domain.Dtos;

namespace Application.Controllers
{
  public class FinancialTransactionController : Controller
  {
    private readonly IFinancialTransactionService _service;
    public FinancialTransactionController(IFinancialTransactionService service) {
      _service = service;
    }

    [HttpGet]
    [Route("/api/financialTransaction")]
    [AllowAnonymous]
    public ActionResult<dynamic> List()
    {
      return Ok(_service.ListFinancialTransaction());
    }

    [HttpPost]
    [Route("/api/financialTransaction")]
    [AllowAnonymous]
    public ActionResult<dynamic> Post([FromBody]FinancialTransaction model)
    {
      return Ok(_service.AddFinancialTransaction(model));
    }

    [HttpPost]
    [Route("/api/transfer")]
    [AllowAnonymous]
    public ActionResult<dynamic> Transfer([FromBody]TransferDto model)
    {
      return Ok(_service.Transfer(model));
    }
  }
}