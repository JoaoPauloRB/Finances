using Blazored.LocalStorage;
using BlazorState;
using Domain.Models;
using Web.Constants;

namespace Web.Features.Users
{
     public partial class UserState : State<UserState>
    {
        public UserState(ISyncLocalStorageService  localStorage) {
            User = localStorage.GetItem<UserDto>(LocalStorageConstants.USER);
        }
        public override void Initialize()
        {}

        public UserDto User { get; private set; }

    }
}