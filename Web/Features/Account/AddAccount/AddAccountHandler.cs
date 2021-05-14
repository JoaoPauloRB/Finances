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
    public class AddAccountHandler : ActionHandler<AddAccountAction>
    {
      private readonly HttpClient _httpClient;
      public AddAccountHandler(IStore store, HttpClient httpClient) : base(store)
      {
        _httpClient = httpClient;
      }
      AccountState AccountState => Store.GetState<AccountState>();
      public override async Task<Unit> Handle(AddAccountAction action, CancellationToken cancellationToken)
      {
        string url = "https://localhost:5001/api/account";
        var response = await _httpClient.PostAsJsonAsync<Account>(url, action.Account);
        var account = await response.Content.ReadFromJsonAsync<Account>();
        if(action.Account.Id != 0) {
          AccountState.Accounts[AccountState.Accounts.FindIndex(u => u.Id == account.Id)] = account;
        } else {
          AccountState.Accounts.Add(account);
        }
        return await Unit.Task;
      }
    }
  }
}