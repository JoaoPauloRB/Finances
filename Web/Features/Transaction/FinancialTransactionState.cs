using System.Collections.Generic;
using BlazorState;
using Domain.Models;

namespace Web.Features.FinancialTransactions
{
    public partial class TransactionState : State<TransactionState>
    {
        public List<Transaction> financialTransactions { get; private set; }
        public override void Initialize()
        {
            financialTransactions = new List<Transaction>();
        }
    }
}