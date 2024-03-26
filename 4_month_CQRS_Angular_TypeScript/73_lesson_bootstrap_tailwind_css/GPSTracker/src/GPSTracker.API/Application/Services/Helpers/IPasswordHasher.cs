namespace GPSTracker.API.Application.Services.Helpers
{
    public interface IPasswordHasher
    {
        string Encrypt(string password, string salt);
        bool Verify(string hash, string password, string salt);
    }
}
