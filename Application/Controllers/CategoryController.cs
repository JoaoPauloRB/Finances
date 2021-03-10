using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Service.Services.Interfaces;

namespace Application.Controllers
{
  public class CategoryController : Controller
  {
    private ICategoryService _service;
    public CategoryController(ICategoryService service) {
      _service = service;
    }

    [HttpGet]
    [Route("/api/category")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> ListAsync()
    {
      return Ok(await _service.ListCategoryAsync());
    }
  }
}