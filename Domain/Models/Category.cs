using Domain.Static;

namespace Domain.Models {
  public class Category {
    public int Id { get; set; }
    public string Description { get; set; }
    public EntryType Type { get; set; }
  }
}