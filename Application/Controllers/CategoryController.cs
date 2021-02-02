using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api.Models;
using Api.Database;

namespace Api.Controllers
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
    public async Task<ActionResult<dynamic>> List()
    {
      return Ok(_uow.CategoryRepository.Get());
    }
  }
}