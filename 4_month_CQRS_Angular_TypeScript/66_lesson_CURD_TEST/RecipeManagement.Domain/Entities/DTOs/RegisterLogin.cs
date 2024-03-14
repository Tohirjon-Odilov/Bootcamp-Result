using System.ComponentModel.DataAnnotations;

namespace RecipeManagement.Domain.Entities.DTOs
{
    public class RegisterLogin
    {
        [MaxLength(40)]
        public required string? Name { get; set; }

        [EmailAddress]
        public required string? Email { get; set; }

        [MaxLength(40)]
        public required string Login { get; set; }

        [MinLength(8)]
        public required string Password { get; set; }

        [MinLength(8)]
        public required string confirmPassword { get; set; }

        [MaxLength(20)]
        public required string Role { get; set; }
    }
}
