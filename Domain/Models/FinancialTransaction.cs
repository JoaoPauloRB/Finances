using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Models
{
  public class FinancialTransaction {
    [Required]
    public int FinancialTransactionId { get; set; }
    public string Description { get; set; }
    public float Amount { get; set; }
    public int AccountId { get; set; }
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public FinancialTransactionType Type { get; set; }
    public DateTime? Creation { get; set; }
    public Account Account { get; set; }
    public Category Category { get; set; }
    public User User { get; set; }
  }
}