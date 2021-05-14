using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using Domain.Models;
using MediatR;

namespace Web.Features.Accounts 
{
  public partial class AccountState
  {
    public class ListAccountsHandler : ActionHandler<ListAccountsAction>
    {
      private readonly HttpClient _httpClient;
      public ListAccountsHandler(IStore store, HttpClient httpClient) : base(store)
      {
        _httpClient = httpClient;
      }

      AccountState AccountState => Store.GetState<AccountState>();

      public override async Task<Unit> Handle(ListAccountsAction action, CancellationToken cancellationToken)
      {
        string url = "https://localhost:5001/api/account";
        AccountState.Accounts = await _httpClient.GetFromJsonAsync<List<Account>>(url);
        return await Unit.Task;
      }
    }
  }
}