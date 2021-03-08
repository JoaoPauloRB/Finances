using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Models
{
  public class FinancialTransaction {
    [Required]
    public int FinancialTransactionId { get; set; }
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public string Description { get; set; }
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public float Amount { get; set; }
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public int AccountId { get; set; }
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public FinancialTransactionType Type { get; set; }
    public DateTime? Creation { get; set; }
    public Account Account { get; set; }
    public Category Category { get; set; }
    public User User { get; set; }
  }
}