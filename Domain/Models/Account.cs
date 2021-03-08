using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
  public class Account
  {
    public int AccountId { get; set; }
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public string Description { get; set; }
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public float Balance { get; set; }
    public int UserId { get; set; }
    public List<FinancialTransaction> FinancialTransactions { get; set; }
    public User User { get; set; }
  }
}