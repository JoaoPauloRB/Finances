using System.Collections.Generic;
using Domain.Models;

namespace Service.Services.Interfaces {
    public interface IAuthService {
        AuthDto Login(User user);
        AuthDto SignUp(User user);
    }
}