using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using Domain.Models;
using MediatR;

namespace Web.Features.FinancialTransactions 
{
  public partial class FinancialTransactionState
  {
    public class AddFinancialTransactionHandler : ActionHandler<AddFinancialTransactionAction>
    {
      private readonly HttpClient _httpClient;
      public AddFinancialTransactionHandler(IStore store, HttpClient httpClient) : base(store)
      {
        _httpClient = httpClient;
      }

      FinancialTransactionState FinancialTransactionState => Store.GetState<FinancialTransactionState>();

      public override async Task<Unit> Handle(AddFinancialTransactionAction action, CancellationToken cancellationToken)
      {
        string url = "https://localhost:5001/financialTransaction";
        var response = await _httpClient.PostAsJsonAsync<FinancialTransaction>(url, action.FinancialTransaction);
        var account = await response.Content.ReadFromJsonAsync<FinancialTransaction>();
        FinancialTransactionState.financialTransactions.Add(account);
        return await Unit.Task;
      }
    }
  }
}