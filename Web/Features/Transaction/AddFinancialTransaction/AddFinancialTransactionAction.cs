using BlazorState;
using Domain.Models;

namespace Web.Features.FinancialTransactions
{
  public partial class FinancialTransactionState
  {
    public class AddFinancialTransactionAction : IAction
    {
      public FinancialTransaction FinancialTransaction { get; private set; }

      public AddFinancialTransactionAction(FinancialTransaction financialTransaction) {
        FinancialTransaction = financialTransaction;
      }
    }
  }
}