namespace GPSTracker.API.Domain.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int DeviceId { get; set; }
        public string CarNumber { get; set; }
        public string Token { get; set; }
    }
}
