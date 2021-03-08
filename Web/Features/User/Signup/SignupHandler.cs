using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorState;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using Web.Constants;

namespace Web.Features.Users
{
  public partial class UserState
  {
    public class SignupHandler : ActionHandler<SignupAction>
    {
      private readonly HttpClient _httpClient;
      private readonly ILocalStorageService _localStorage;
      private readonly NavigationManager _navigation;
      public SignupHandler(IStore store, HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigation) : base(store)
      {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _navigation = navigation;
      }

      UserState UserState => Store.GetState<UserState>();

      public override async Task<Unit> Handle(SignupAction action, CancellationToken cancellationToken)
      {
        string url = "https://localhost:5001/api/signup";
        UserState.User = await (await _httpClient.PostAsJsonAsync<User>(url, action.User))
          .Content.ReadFromJsonAsync<UserDto>();
        await _localStorage.SetItemAsync<UserDto>(LocalStorageConstants.USER, UserState.User);
        _navigation.NavigateTo("");

        return await Unit.Task;
      }
    }
  }
}