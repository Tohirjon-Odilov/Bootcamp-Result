using System.Text.Json.Serialization;

namespace FutureProjects.Domain.Entities.DTOs
{
    public class UserDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
    }
}
