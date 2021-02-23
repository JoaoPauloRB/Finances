using System.Collections.Generic;

namespace Domain.Models
{
  public class Account
  {
    public int AccountId { get; set; }
    public string Description { get; set; }
    public float Balance { get; set; }
    public int UserId { get; set; }
    public List<FinancialTransaction> FinancialTransactions { get; set; }
    public User User { get; set; }
  }
}