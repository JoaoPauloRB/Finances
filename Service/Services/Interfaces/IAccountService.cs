using System.Collections.Generic;
using Domain.Models;

namespace Service.Services.Interfaces {
    public interface IAccountService {
        Account AddAccount(Account account);
        Account UpdateAccount(Account account);
        IEnumerable<Account> ListAccounts();
    }
}