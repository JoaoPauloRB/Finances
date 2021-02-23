using Blazored.LocalStorage;
using BlazorState;
using Domain.Models;
using Web.Constants;

namespace Web.Features.Users
{
     public partial class UserState : State<UserState>
    {
        public override void Initialize()
        {
            User = null;
        }

        public UserDto User { get; private set; }

  }
}