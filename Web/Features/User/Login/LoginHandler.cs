using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorState;
using Domain.Models;
using MediatR;
using Web.Constants;

namespace Web.Features.Users
{
  public partial class UserState
  {
    public class LoginHandler : ActionHandler<LoginAction>
    {
      private readonly HttpClient _httpClient;
      private readonly ILocalStorageService _localStorage;
      public LoginHandler(IStore store, HttpClient httpClient, ILocalStorageService localStorage) : base(store)
      {
        _httpClient = httpClient;
        _localStorage = localStorage;
      }

      UserState UserState => Store.GetState<UserState>();

      public override async Task<Unit> Handle(LoginAction action, CancellationToken cancellationToken)
      {
        string url = "https://localhost:5001/api/login";
        UserState.User = await (await _httpClient.PostAsJsonAsync<User>(url, action.User))
          .Content.ReadFromJsonAsync<UserDto>();
        await _localStorage.SetItemAsync<UserDto>(LocalStorageConstants.USER, UserState.User);

        return await Unit.Task;
      }
    }
  }
}