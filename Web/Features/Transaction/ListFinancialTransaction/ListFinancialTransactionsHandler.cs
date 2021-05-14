using System.Collections.Generic;
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
    public class ListFinancialTransactionsHandler : ActionHandler<ListFinancialTransactionsAction>
    {
      private readonly HttpClient _httpClient;
      public ListFinancialTransactionsHandler(IStore store, HttpClient httpClient) : base(store)
      {
        _httpClient = httpClient;
      }

      FinancialTransactionState FinancialTransactionState => Store.GetState<FinancialTransactionState>();

      public override async Task<Unit> Handle(ListFinancialTransactionsAction action, CancellationToken cancellationToken)
      {
        string url = "https://localhost:5001/api/financialTransaction";
        FinancialTransactionState.financialTransactions = await _httpClient.GetFromJsonAsync<List<FinancialTransaction>>(url);
        return await Unit.Task;
      }
    }
  }
}