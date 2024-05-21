using Microsoft.AspNetCore.Identity;

namespace PersonalBrand.Domain.Entities.Auth
{
    public class UserModel : IdentityUser<long>
    {
        public string FirstName { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTimeOffset ModifiedAt { get; set; }
        public DateTimeOffset DeletedAt { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
