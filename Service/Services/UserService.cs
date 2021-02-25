using System.Linq;
using Domain.Models;
using Infra.Data;
using Service.Services.Interfaces;
using Service.Utils;
using Microsoft.AspNetCore.Identity;

namespace Service.Services {
    public class UserService : IUserService {
        private readonly UnitOfWork _uow;
        private readonly PasswordHasher<User> _hasher;
        public UserService(UnitOfWork uow) {
            _uow = uow;
            _hasher = new PasswordHasher<User>();
        }
        public User SignUp(User user) {
            
            user.Password = _hasher.HashPassword(user, user.Password);
            _uow.UserRepository.Insert(user);
            _uow.Save();
            return user;
        }

        public User Login(User userLogin) {
            var user = _uow.UserRepository.Get(u => u.Email == userLogin.Email).FirstOrDefault();
            if(user != null) {
                var result = _hasher.VerifyHashedPassword(user, user.Password, userLogin.Password);
                System.Console.WriteLine(user.UserId);
                return result == PasswordVerificationResult.Failed ? null : user;
            }
            return null;
        }
    }
}