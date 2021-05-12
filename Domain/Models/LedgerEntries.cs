using System;
using System.ComponentModel.DataAnnotations;
using Domain.Static;

namespace Domain.Models
{
  public class LedgerEntries {
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public EntryType Type { get; set; }
    public int AccountId { get; set; }
    public int TransactionId { get; set; }
    public Account Account { get; set; }
    public Transaction Transaction { get; set; }
  }
}