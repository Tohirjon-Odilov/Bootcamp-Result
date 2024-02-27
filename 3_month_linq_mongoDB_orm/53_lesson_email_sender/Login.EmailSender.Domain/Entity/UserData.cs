using System.ComponentModel.DataAnnotations;

namespace Login.EmailSender.Domain.Entity
{
    public class UserData
    {
        public int Id { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [MinLength(8), MaxLength(20)]
        public required string Password { get; set; }
        [Required]
        [Length(4, 4)]
        public string VerificationPassword { get; set; } = string.Empty;
    }
}
