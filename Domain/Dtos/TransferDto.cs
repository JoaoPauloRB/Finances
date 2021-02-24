namespace Domain.Dtos {
    public class TransferDto {
        public int AccountFrom { get; set; }
        public int AccountTo { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
    }
}