using Blazored.LocalStorage;
using BlazorState;
using Domain.Models;
using Web.Constants;

namespace Web.Features.Users
{
     public partial class UserState : State<UserState>
    {
        ISyncLocalStorageService _localStorage;

        public UserState(ISyncLocalStorageService localStorageService) {
            _localStorage = localStorageService;
        }
        public UserDto User { get; private set; }
        public override void Initialize()
        {
            User = _localStorage.GetItem<UserDto>(LocalStorageConstants.USER);
        }
  }
}