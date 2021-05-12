using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
  public class Transaction {
    [Required]
    public int Id { get; set; }
    [Required (ErrorMessage ="Campo deve ser preenchido")]
    public string Description { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Campo deve ser preenchido")]
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public DateTime? Creation { get; set; }
    public User User { get; set; }
    public List<LedgerEntries> LedgerEntries { get; set; }
  }
}