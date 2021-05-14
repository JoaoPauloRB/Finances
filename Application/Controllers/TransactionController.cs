using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using Service.Services.Interfaces;
using Domain.Dtos;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Controllers
{
  public class TransactionController : Controller
  {
    private readonly ITransactionService _service;
    public TransactionController(ITransactionService service) {
      _service = service;
    }

    // [HttpGet]
    // [Route("/api/financialTransaction")]
    // [AllowAnonymous]
    // public async Task<ActionResult<dynamic>> ListAsync()
    // {
    //   var listTransactions = await _service.ListFinancialTransactionByUserAsync(Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
    //   return Ok(listTransactions);
    // }

    // [HttpPost]
    // [Route("/api/financialTransaction")]
    // [AllowAnonymous]
    // public ActionResult<dynamic> Post([FromBody]Transaction model)
    // {
    //   model.UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    //   return Ok(_service.AddFinancialTransaction(model));
    // }

    // [HttpPost]
    // [Route("/api/transfer")]
    // [AllowAnonymous]
    // public ActionResult<dynamic> Transfer([FromBody]TransferDto model)
    // {
    //   model.UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    //   return Ok(_service.Transfer(model));
    // }
  }
}