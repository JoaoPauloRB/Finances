using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos {
    public class TransferDto {
        [Required (ErrorMessage="Campo deve ser preenchido")]
        public int AccountFrom { get; set; }
        [Required (ErrorMessage="Campo deve ser preenchido")]
        public int AccountTo { get; set; }
        [Required (ErrorMessage="Campo deve ser preenchido")]
        public float Amount { get; set; }
        public int UserId { get; set; }
    }
}