namespace GPSTracker.API.Infrastructure.Extensions
{
    public class UrlCombainer
    {
        public static string Combine(string route, DateTime fromDate, DateTime toDate, int deviceId = 3)
        {
            return $"{route}?from={fromDate.ToString("yyyy-MM-ddTHH\\%3Amm\\%3Ass.fffZ")}&to={toDate.ToString("yyyy-MM-ddTHH\\%3Amm\\%3Ass.fffZ")}&deviceId={deviceId}";
        }
    }
}
