﻿namespace GPSTracker.API.Domain.Entities
{
    public class Stop
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
        public int? positionId { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public object address { get; set; }
        public int? duration { get; set; }
        public int? engineHours { get; set; }
    }
}
