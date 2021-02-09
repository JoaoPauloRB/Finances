using System.Collections.Generic;
using BlazorState;
using Domain.Models;

namespace Web.Features.Accounts
{
    public partial class AccountState : State<AccountState>
    {
        public List<Account> accounts { get; private set; }
        public override void Initialize()
        {
            accounts = new List<Account>();
        }
    }
}