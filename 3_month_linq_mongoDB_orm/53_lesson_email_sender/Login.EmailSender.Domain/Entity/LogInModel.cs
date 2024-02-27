using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Login.EmailSender.Domain.Entity
{
    public class LogInModel
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }

        [JsonIgnore]
        public string? Body { get; set; }
    }
}
