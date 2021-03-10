using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Models;

namespace Service.Services.Interfaces {
    public interface IFinancialTransactionService {
        FinancialTransaction AddFinancialTransaction(FinancialTransaction account);
        Task<IEnumerable<FinancialTransaction>> ListFinancialTransactionByUserAsync(int UserId);
        IEnumerable<FinancialTransaction> Transfer(TransferDto transfer);
    }
}