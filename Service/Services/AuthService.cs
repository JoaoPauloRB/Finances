using System.Collections.Generic;
using Domain.Models;
using Infra.Data;
using Service.Services.Interfaces;

namespace Service.Services {
    public class AuthService : IAuthService {
        private readonly UnitOfWork _uow;
        public AuthService(UnitOfWork uow) {
            _uow = uow;
        }
        public AuthDto SignUp(User user) {
            _uow.UserRepository.Insert(user);
            _uow.Save();
            return user;
        }

        public IEnumerable<Account> ListAccounts() {
            return _uow.AccountRepository.Get();
        }
    }
}