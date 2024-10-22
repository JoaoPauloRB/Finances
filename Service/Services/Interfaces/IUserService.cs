using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Service.Services.Interfaces {
    public interface IUserService {
        Task<User> LoginAsync(User user);
        User SignUp(User user);
    }
}