using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User {
        public int UserId { get; set; }
        [Required (ErrorMessage ="Campo deve ser preenchido")]
        public string Name { get; set; }
        [Required (ErrorMessage ="Campo deve ser preenchido")]
        [EmailAddress (ErrorMessage ="Deve ser um email")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Email { get; set; }
        [Required (ErrorMessage ="Campo deve ser preenchido")]
        public string Password { get; set; }
    }
}