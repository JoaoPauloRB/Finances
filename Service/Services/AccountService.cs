using System.Collections.Generic;
using Domain.Models;
using Infra.Data;
using Service.Services.Interfaces;

namespace Service.Services {
    public class AccountService : IAccountService {
        private readonly UnitOfWork _uow;
        public AccountService(UnitOfWork uow) {
            _uow = uow;
        }
        public Account AddAccount(Account account) {
            _uow.AccountRepository.Insert(account);
            _uow.Save();
            return account;
        }

        public IEnumerable<Account> ListAccounts() {
            return _uow.AccountRepository.Get();
        }
    }
}