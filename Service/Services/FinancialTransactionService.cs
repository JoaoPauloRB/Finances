using System.Collections.Generic;
using Domain.Enums;
using Domain.Models;
using Infra.Data;
using Service.Services.Interfaces;

namespace Service.Services {
    public class FinancialTransactionService : IFinancialTransactionService {
        private readonly UnitOfWork _uow;
        public FinancialTransactionService(UnitOfWork uow) {
            _uow = uow;
        }
        public FinancialTransaction AddFinancialTransaction(FinancialTransaction financialTransaction) {
            var account = _uow.AccountRepository.GetByID(financialTransaction.AccountId);
            account.Balance += (financialTransaction.Type == FinancialTransactionType.Credit ? 1 : -1) * financialTransaction.Amount;
            _uow.AccountRepository.Update(account);

            _uow.FinancialTransactionRepository.Insert(financialTransaction);
            _uow.Save();
            return financialTransaction;
        }
        public IEnumerable<FinancialTransaction> ListFinancialTransaction() {
            return _uow.FinancialTransactionRepository.Get();
        }
    }
}