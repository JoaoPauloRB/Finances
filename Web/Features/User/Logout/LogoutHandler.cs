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
    public class LogoutHandler : ActionHandler<LogoutAction>
    {
      private readonly ILocalStorageService _localStorage;
      public LogoutHandler(IStore store, ILocalStorageService localStorage) : base(store)
      {
        _localStorage = localStorage;
      }

      UserState UserState => Store.GetState<UserState>();

      public override async Task<Unit> Handle(LogoutAction action, CancellationToken cancellationToken)
      {
        UserState.User = null;
        await _localStorage.RemoveItemAsync(LocalStorageConstants.USER);

        return await Unit.Task;
      }
    }
  }
}