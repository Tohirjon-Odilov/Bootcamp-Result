namespace GPSTracker.API.Domain.Entities.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string RefreshToken { get; set; }
        public string Salt { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
