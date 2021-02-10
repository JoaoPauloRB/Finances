using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using Service.Services.Interfaces;
using System;

namespace Application.Controllers
{
  public class FinancialTransactionController : Controller
  {
    private readonly IFinancialTransactionService _service;
    public FinancialTransactionController(IFinancialTransactionService service) {
      _service = service;
    }

    [HttpPost]
    [Route("/financialTransaction")]
    [AllowAnonymous]
    public ActionResult<dynamic> Post([FromBody]FinancialTransaction model)
    {
      Console.WriteLine(model.ToString());
      return Ok(_service.AddFinancialTransaction(model));
    }
  }
}