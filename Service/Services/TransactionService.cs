using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Models;
using Infra.Data;
using Service.Services.Interfaces;

namespace Service.Services {
public class TransactionService : ITransactionService
{
        private readonly UnitOfWork _uow;
        public TransactionService(UnitOfWork uow)
        {
            _uow = uow;
        }

    }
}