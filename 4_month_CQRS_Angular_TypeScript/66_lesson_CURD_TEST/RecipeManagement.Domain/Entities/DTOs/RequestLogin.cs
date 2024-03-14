using System.ComponentModel.DataAnnotations;

namespace RecipeManagement.Domain.Entities.DTOs
{
    public class RequestLogin
    {
        [MaxLength(40)]
        public required string Login { get; set; }

        [MinLength(8)]
        public required string Password { get; set; }
    }
}
