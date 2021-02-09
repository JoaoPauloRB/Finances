using BlazorState;
using Domain.Models;

namespace Web.Features.Accounts
{
  public partial class AccountState
  {
    public class AddAccountAction : IAction
    {
      public Account Account { get; private set; }

      public AddAccountAction(Account account) {
        Account = account;
      }
    }
  }
}