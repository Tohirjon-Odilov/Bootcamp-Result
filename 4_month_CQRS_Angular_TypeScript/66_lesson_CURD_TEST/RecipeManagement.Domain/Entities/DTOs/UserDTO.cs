using System.ComponentModel.DataAnnotations;

namespace RecipeManagement.Domain.Entities.DTOs
{
    public class UserDTO
    {
        [MaxLength(40)]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [MaxLength(40)]
        public required string Login { get; set; }

        [MinLength(8)]
        public required string Password { get; set; }

        [MaxLength(20)]
        public required string Role { get; set; }

        [MaxLength(5)]
        public string? confirmationCode { get; set; }
    }
}
