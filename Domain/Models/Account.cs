using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
  public class Account
  {
    public int Id { get; set; }
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public string Description { get; set; }
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public float Balance { get; set; }
    public int UserId { get; set; }
    public int CurrencyTypeId { get; set; }
    public User User { get; set; }
    public List<LedgerEntries> LedgerEntries { get; set; }
    public CurrencyType CurrencyType { get; set; }
  }
}