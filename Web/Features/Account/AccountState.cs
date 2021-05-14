using System.Collections.Generic;
using BlazorState;
using Domain.Models;

namespace Web.Features.Accounts
{
    public partial class AccountState : State<AccountState>
    {
        public List<Account> Accounts { get; private set; }
        public override void Initialize()
        {
            Accounts = new List<Account>();
        }
    }
}