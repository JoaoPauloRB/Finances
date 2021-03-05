using System;
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
    public class SignupHandler : ActionHandler<SignupAction>
    {
      private readonly HttpClient _httpClient;
      private readonly ILocalStorageService _localStorage;
      public SignupHandler(IStore store, HttpClient httpClient, ILocalStorageService localStorage) : base(store)
      {
        _httpClient = httpClient;
        _localStorage = localStorage;
      }

      UserState UserState => Store.GetState<UserState>();

      public override async Task<Unit> Handle(SignupAction action, CancellationToken cancellationToken)
      {
        string rootUrl = Environment.GetEnvironmentVariable("ROOT_API_URL") ?? "https://localhost:5001/api";
        Console.WriteLine(rootUrl);
        string url = rootUrl + "/signup";
        UserState.User = await (await _httpClient.PostAsJsonAsync<User>(url, action.User))
          .Content.ReadFromJsonAsync<UserDto>();
        await _localStorage.SetItemAsync<UserDto>(LocalStorageConstants.USER, UserState.User);

        return await Unit.Task;
      }
    }
  }
}