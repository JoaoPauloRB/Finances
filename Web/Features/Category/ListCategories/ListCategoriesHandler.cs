using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using Domain.Models;
using MediatR;

namespace Web.Features.Categories
{
  public partial class CategoryState
  {
    public class ListCategoriesHandler : ActionHandler<ListCategoriesAction>
    {
      private readonly HttpClient _httpClient;
      public ListCategoriesHandler(IStore store, HttpClient httpClient) : base(store)
      {
        _httpClient = httpClient;
      }

      CategoryState CategoryState => Store.GetState<CategoryState>();

      public override async Task<Unit> Handle(ListCategoriesAction action, CancellationToken cancellationToken)
      {
        string url = "https://localhost:5001/api/category";
        CategoryState.Categories = await _httpClient.GetFromJsonAsync<List<Category>>(url);
        return await Unit.Task;
      }
    }
  }
}