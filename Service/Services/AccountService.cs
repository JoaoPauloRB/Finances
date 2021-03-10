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
            accountToUpdate.Description = account.Description;
            accountToUpdate.Balance = account.Balance;
            _uow.AccountRepository.Update(accountToUpdate);
            _uow.Save();
            return account;
        }

        public async Task<IEnumerable<Account>> ListAccountsByUserAsync(int UserId) {
            return await _uow.AccountRepository.GetAsync(a => a.UserId == UserId);
        }
    }
}