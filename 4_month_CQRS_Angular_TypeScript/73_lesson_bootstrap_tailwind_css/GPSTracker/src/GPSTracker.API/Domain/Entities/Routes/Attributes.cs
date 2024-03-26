using System.Text.Json.Serialization;

namespace GPSTracker.API.Domain.Entities.Routes
{
    public class Attributes
    {
        public int? priority { get; set; }
        public int? sat { get; set; }
        [JsonPropertyName("event")]
        public int? @event { get; set; }
        public bool? ignition { get; set; }
        public bool? motion { get; set; }
        public int? rssi { get; set; }
        public int? io200 { get; set; }
        public int? io69 { get; set; }
        public double? pdop { get; set; }
        public double? hdop { get; set; }
        public double? power { get; set; }
        public double? battery { get; set; }
        public int? io68 { get; set; }
        [JsonPropertyName("operator")]
        public int? @operator { get; set; }
        public int? odometer { get; set; }
        public double? distance { get; set; }
        public double? totalDistance { get; set; }
        public object hours { get; set; }
    }
}
