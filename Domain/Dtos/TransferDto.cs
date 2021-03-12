using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos {
    public class TransferDto {
        [Range(1, int.MaxValue, ErrorMessage = "Campo deve ser preenchido")]
        [Required (ErrorMessage="Campo deve ser preenchido")]
        public int AccountFrom { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Campo deve ser preenchido")]
        [Required (ErrorMessage="Campo deve ser preenchido")]
        public int AccountTo { get; set; }
        [Range(1, float.MaxValue, ErrorMessage = "Campo deve ser preenchido")]
        [Required (ErrorMessage="Campo deve ser preenchido")]
        public float Amount { get; set; }
        public int UserId { get; set; }
    }
}