using System.Collections.Generic;
using Domain.Models;

namespace Service.Services.Interfaces {
    public interface IFinancialTransactionService {
        FinancialTransaction AddFinancialTransaction(FinancialTransaction account);
        IEnumerable<FinancialTransaction> ListFinancialTransaction();
    }
}