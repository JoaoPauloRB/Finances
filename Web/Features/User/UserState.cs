using Blazored.LocalStorage;
using BlazorState;
using Domain.Models;
using Web.Constants;

namespace Web.Features.Users
{
     public partial class UserState : State<UserState>
    {
        // private readonly ISyncLocalStorageService _localStorageSync;
        // public UserState(ISyncLocalStorageService localStorage) {
        //     _localStorageSync = localStorage;
        // }
        public override void Initialize()
        {
            User = new UserDto();
            // if(_localStorageSync != null) {
            //     User = _localStorageSync.GetItem<UserDto>(LocalStorageConstants.USER) ?? User;
            // }            
        }

        public UserDto User { get; private set; }

    }
}