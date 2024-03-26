namespace GPSTracker.API.Domain.Entities
{
    public class Trip
    {
        public int? deviceId { get; set; }
        public string deviceName { get; set; }
        public double? distance { get; set; }
        public double? averageSpeed { get; set; }
        public double? maxSpeed { get; set; }
        public double? spentFuel { get; set; }
        public double? startOdometer { get; set; }
        public double? endOdometer { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
        public int? startPositionId { get; set; }
        public int? endPositionId { get; set; }
        public double? startLat { get; set; }
        public double? startLon { get; set; }
        public double? endLat { get; set; }
        public double? endLon { get; set; }
        public string startAddress { get; set; }
        public string endAddress { get; set; }
        public int? duration { get; set; }
        public object driverUniqueId { get; set; }
        public object driverName { get; set; }
    }
}
