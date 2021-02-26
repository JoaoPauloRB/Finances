using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User {
        public int UserId { get; set; }
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}