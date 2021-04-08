using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.Toast.Services;
using BlazorState;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using Web.Constants;

namespace Web.Features.Users
{
  public partial class UserState
  {
    public class LoginHandler : ActionHandler<LoginAction>
    {
      private readonly HttpClient _httpClient;
      private readonly ILocalStorageService _localStorage;
      private readonly NavigationManager _navigation;
      private readonly IToastService _toastService;
      public LoginHandler(
        IStore store,
        HttpClient httpClient,
        ILocalStorageService localStorage,
        NavigationManager navigation,
        IToastService toastService
        ) : base(store)
      {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _navigation = navigation;
        _toastService = toastService;
      }

      UserState UserState => Store.GetState<UserState>();

      public override async Task<Unit> Handle(LoginAction action, CancellationToken cancellationToken)
      {
        string url = "https://localhost:5001/api/login";
        
        var response = await _httpClient.PostAsJsonAsync<User>(url, action.User);
        if(response.StatusCode == System.Net.HttpStatusCode.OK) {
          UserState.User = await response.Content.ReadFromJsonAsync<UserDto>();
          await _localStorage.SetItemAsync<UserDto>(LocalStorageConstants.USER, UserState.User);
          _navigation.NavigateTo("");
        } else {
          var erro = await response.Content.ReadFromJsonAsync<Error>();
          _toastService.ShowError(erro.Message, "Erro");
        }
        
        return await Unit.Task;
      }
    }
  }
}