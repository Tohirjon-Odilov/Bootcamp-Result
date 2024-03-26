namespace GPSTracker.API.Application.DataTransferObjects.Auth
{
    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
