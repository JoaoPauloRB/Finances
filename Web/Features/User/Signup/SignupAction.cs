using BlazorState;
using Domain.Models;

namespace Web.Features.Users
{
  public partial class UserState
  {
    public class SignupAction : IAction
    {
      public User User { get; private set; }
      public SignupAction(User user) {
        User = user;
      }
    }
  }
}