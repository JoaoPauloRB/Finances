using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using Infra.Data;

namespace Application.Controllers
{
  public class CategoryController : Controller
  {
    private readonly UnitOfWork _uow;
    public CategoryController(UnitOfWork uow) {
      _uow = uow;
    }

    [HttpGet]
    [Route("/category")]
    [AllowAnonymous]
    public ActionResult<dynamic> List()
    {
      return Ok(_uow.CategoryRepository.Get());
    }
  }
}