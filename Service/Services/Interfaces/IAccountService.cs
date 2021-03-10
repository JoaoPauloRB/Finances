using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Service.Services.Interfaces {
    public interface IAccountService {
        Account AddAccount(Account account);
        Account UpdateAccount(Account account);
        Task<IEnumerable<Account>> ListAccountsByUserAsync(int UserId);
    }
}