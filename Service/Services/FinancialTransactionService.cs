using System.Collections.Generic;
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
            _uow.FinancialTransactionRepository.Insert(financialTransaction);
            _uow.Save();
            return financialTransaction;
        }
        public IEnumerable<FinancialTransaction> ListFinancialTransaction() {
            return _uow.FinancialTransactionRepository.Get();
        }
    }
}