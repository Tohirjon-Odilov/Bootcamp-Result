namespace GPSTracker.API.Application.DataTransferObjects.Devices
{
    public class DeviceCreationDTO
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CarNumber { get; set; }
        public int DeviceId { get; set; }
    }
}
