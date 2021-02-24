using System.Collections.Generic;
using Domain.Dtos;
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
            return _uow.FinancialTransactionRepository.Get(includeProperties:"Account");
        }

        public IEnumerable<FinancialTransaction> Transfer(TransferDto transfer) {
            var transactionFrom = new FinancialTransaction();
            var transactionTo = new FinancialTransaction();
            var accountFrom = _uow.AccountRepository.GetByID(transfer.AccountFrom);
            var accountTo = _uow.AccountRepository.GetByID(transfer.AccountTo);
            accountFrom.Balance -= transfer.Amount;
            accountTo.Balance += transfer.Amount;
            _uow.AccountRepository.Update(accountFrom);
            _uow.AccountRepository.Update(accountTo);

            transactionFrom.Type = FinancialTransactionType.Debit;
            transactionFrom.Amount = transfer.Amount;
            transactionFrom.AccountId = transfer.AccountFrom;
            transactionFrom.Description = $"Tranferência para {accountFrom.Description}";
            transactionFrom.UserId = transfer.UserId;
            transactionFrom.CategoryId = 1;

            transactionTo.Type = FinancialTransactionType.Credit;
            transactionTo.Amount = transfer.Amount;
            transactionTo.AccountId = transfer.AccountTo;
            transactionTo.Description = $"Tranferência de {accountTo.Description}";
            transactionTo.UserId = transfer.UserId;
            transactionTo.CategoryId = 1;

            _uow.FinancialTransactionRepository.Insert(transactionFrom);
            _uow.FinancialTransactionRepository.Insert(transactionTo);
            _uow.Save();

            var transactions = new List<FinancialTransaction>() {
                transactionFrom,
                transactionTo
            };
            return transactions;
        }
    }
}