using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorState;
using MediatR;
using Microsoft.AspNetCore.Components;
using Web.Constants;

namespace Web.Features.Users
{
  public partial class UserState
  {
    public class LogoutHandler : ActionHandler<LogoutAction>
    {
      private readonly ILocalStorageService _localStorage;
      private readonly NavigationManager _navigation;
      public LogoutHandler(IStore store, ILocalStorageService localStorage, NavigationManager navigation) : base(store)
      {
        _localStorage = localStorage;
        _navigation = navigation;
      }

      UserState UserState => Store.GetState<UserState>();

      public override async Task<Unit> Handle(LogoutAction action, CancellationToken cancellationToken)
      {
        UserState.User = null;
        await _localStorage.RemoveItemAsync(LocalStorageConstants.USER);
        _navigation.NavigateTo("/login");

        return await Unit.Task;
      }
    }
  }
}