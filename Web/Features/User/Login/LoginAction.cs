using System;
using BlazorState;
using Domain.Models;

namespace Web.Features.Users
{
  public partial class UserState
  {
    public class LoginAction : IAction
    {
      public User User { get; private set; }
      public LoginAction(User user) {
        User = user;
      }
    }
  }
}