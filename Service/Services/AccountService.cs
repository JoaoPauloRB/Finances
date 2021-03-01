using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Account UpdateAccount(Account account) {
            var accountToUpdate = _uow.AccountRepository.GetByID(account.AccountId);
            accountToUpdate.Balance = account.Balance;
            _uow.AccountRepository.Update(accountToUpdate);
            _uow.Save();
            return account;
        }

        public IEnumerable<Account> ListAccountsByUser(int UserId) {
            return _uow.AccountRepository.Get(a => a.UserId == UserId);
        }
    }
}