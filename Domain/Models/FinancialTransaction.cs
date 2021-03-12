using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Models
{
  public class FinancialTransaction {
    [Required]
    public int FinancialTransactionId { get; set; }
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public string Description { get; set; }
    [Range(1, float.MaxValue, ErrorMessage = "Campo deve ser preenchido")]
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public float Amount { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Campo deve ser preenchido")]
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public int AccountId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Campo deve ser preenchido")]
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