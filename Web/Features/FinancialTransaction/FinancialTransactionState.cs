using System.Collections.Generic;
using BlazorState;
using Domain.Models;

namespace Web.Features.FinancialTransactions
{
    public partial class FinancialTransactionState : State<FinancialTransactionState>
    {
        public List<FinancialTransaction> financialTransactions { get; private set; }
        public override void Initialize()
        {
            financialTransactions = new List<FinancialTransaction>();
        }
    }
}