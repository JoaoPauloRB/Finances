using Domain.Static;

namespace Domain.Models {
    public class CurrencyType {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Culture { get; set; }
        public InitialsType Initials { get; set; }
    }
}