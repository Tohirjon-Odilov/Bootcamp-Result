namespace GPSTracker.API.Domain.Entities.Events
{
    public class Event
    {
        public int? id { get; set; }
        public Attributes attributes { get; set; }
        public int? deviceId { get; set; }
        public string type { get; set; }
        public DateTime? eventTime { get; set; }
        public int? positionId { get; set; }
        public int? geofenceId { get; set; }
        public int? maintenanceId { get; set; }
    }
}
