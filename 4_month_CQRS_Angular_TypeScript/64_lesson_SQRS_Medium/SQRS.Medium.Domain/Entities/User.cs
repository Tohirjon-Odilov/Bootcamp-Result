namespace SQRS.Medium.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public string? Email { get; set; }
        public required string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string? PicturePath { get; set; }
        public int Followers { get; set; }
        public DateTimeOffset JoinDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset ModifiedDate { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
