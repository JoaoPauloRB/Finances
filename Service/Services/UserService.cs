using System.Linq;
using Domain.Models;
using Infra.Data;
using Service.Services.Interfaces;
using Service.Utils;

namespace Service.Services {
    public class UserService : IUserService {
        private readonly UnitOfWork _uow;
        public UserService(UnitOfWork uow) {
            _uow = uow;
        }
        public User SignUp(User user) {
            user.Password = Hashs.HashPassword(user.Password);
            _uow.UserRepository.Insert(user);
            _uow.Save();
            return user;
        }

        public User Login(User user) {
            string hashedPassword = Hashs.HashPassword(user.Password);
            return _uow.UserRepository.Get(u => u.Email == user.Email && u.Password == hashedPassword).FirstOrDefault();
        }
    }
}