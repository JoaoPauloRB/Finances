using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using Domain.Dtos;
using Domain.Models;
using MediatR;

namespace Web.Features.FinancialTransactions 
{
  public partial class FinancialTransactionState
  {
    public class TransferHandler : ActionHandler<TransferAction>
    {
      private readonly HttpClient _httpClient;
      public TransferHandler(IStore store, HttpClient httpClient) : base(store)
      {
        _httpClient = httpClient;
      }

      FinancialTransactionState FinancialTransactionState => Store.GetState<FinancialTransactionState>();

      public override async Task<Unit> Handle(TransferAction action, CancellationToken cancellationToken)
      {
        string url = "https://localhost:5001/transfer";
        var response = await _httpClient.PostAsJsonAsync<TransferDto>(url, action.Transfer);
        var accounts = await response.Content.ReadFromJsonAsync<List<FinancialTransaction>>();
        FinancialTransactionState.financialTransactions.AddRange(accounts);
        return await Unit.Task;
      }
    }
  }
}