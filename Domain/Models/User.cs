using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User {
        public int Id { get; set; }
        [Required (ErrorMessage ="Campo deve ser preenchido")]
        public string Name { get; set; }
        [Required (ErrorMessage ="Campo deve ser preenchido")]
        [EmailAddress (ErrorMessage ="Deve ser um email válido")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Email { get; set; }
        [Required (ErrorMessage ="Campo deve ser preenchido")]
        public string Password { get; set; }
    }
}