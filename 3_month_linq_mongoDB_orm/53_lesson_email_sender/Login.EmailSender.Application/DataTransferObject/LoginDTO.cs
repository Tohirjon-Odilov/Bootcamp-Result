using System.ComponentModel.DataAnnotations;

namespace Login.EmailSender.Application.DataTransferObject
{
    public class LoginDTO
    {
        [EmailAddress]
        public required string Email { get; set; }

        [MinLength(8), MaxLength(20)]
        public required string Password { get; set; } = "0000";
    }
}
