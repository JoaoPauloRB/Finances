using Domain.Enums;

namespace Domain.Models {
  public class Category {
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public FinancialTransactionType Type { get; set; }
  }
}