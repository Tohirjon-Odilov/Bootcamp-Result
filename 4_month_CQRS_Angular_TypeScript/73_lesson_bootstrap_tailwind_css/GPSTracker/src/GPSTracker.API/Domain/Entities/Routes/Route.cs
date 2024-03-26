namespace GPSTracker.API.Domain.Entities.Routes
{
    public class Route
    {
        public int? id { get; set; }
        public Attributes attributes { get; set; }
        public int? deviceId { get; set; }
        public string protocol { get; set; }
        public DateTime? serverTime { get; set; }
        public DateTime? deviceTime { get; set; }
        public DateTime? fixTime { get; set; }
        public bool? outdated { get; set; }
        public bool? valid { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public double? altitude { get; set; }
        public double? speed { get; set; }
        public double? course { get; set; }
        public object address { get; set; }
        public double? accuracy { get; set; }
        public object network { get; set; }
        public object geofenceIds { get; set; }
    }
}
