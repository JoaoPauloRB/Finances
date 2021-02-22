using System.Collections.Generic;
using BlazorState;
using Domain.Models;

namespace Web.Features.Authentication
{
    public partial class AuthenticationState : State<AuthenticationState>
    {
        public List<Account> accounts { get; private set; }
        public override void Initialize()
        {
            accounts = new List<Account>();
        }
    }
}