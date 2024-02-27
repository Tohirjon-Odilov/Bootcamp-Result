using System.ComponentModel.DataAnnotations;

namespace Login.EmailSender.Domain.Entity
{
    public class SignUpModel
    {
        public int id { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [MinLength(8), MaxLength(20)]
        public required string Password { get; set; }
    }
}
