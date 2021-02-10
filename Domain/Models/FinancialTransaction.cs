using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Models
{
  public class FinancialTransaction {
    public int FinancialTransactionId { get; set; }
    public string Description { get; set; }
    public float Amount { get; set; }
    public int AccountId { get; set; }
    public int CategotyId { get; set; }
    public FinancialTransactionType Type { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Creation { get; set; }
    public Account Account { get; set; }
    public User User { get; set; }
    public Category Category { get; set; }
  }
}