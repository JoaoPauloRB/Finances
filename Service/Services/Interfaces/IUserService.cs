using System.Collections.Generic;
using Domain.Models;

namespace Service.Services.Interfaces {
    public interface IUserService {
        User Login(User user);
        User SignUp(User user);
    }
}