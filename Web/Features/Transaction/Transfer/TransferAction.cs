using BlazorState;
using Domain.Dtos;

namespace Web.Features.FinancialTransactions
{
  public partial class FinancialTransactionState
  {
    public class TransferAction : IAction
    {
      public TransferDto Transfer { get; private set; }

      public TransferAction(TransferDto transfer) {
        Transfer = transfer;
      }
    }
  }
}