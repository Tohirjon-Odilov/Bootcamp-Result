using GPSTracker.API.Domain.Entities;
using GPSTracker.API.Infrastructure.Extensions;
using Newtonsoft.Json;

namespace GPSTracker.API.Infrastructure.Broker
{
    public partial class ProGPSAPIService
    {
        public async Task<List<Stop>> GetStops(DateTime fromDate, DateTime endDate, string carNumber)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(_httpClient.BaseAddress, UrlCombainer.Combine(_configuration.Stops, fromDate, endDate, await GetDeviceIdFromNumber(carNumber)));
            request.Method = HttpMethod.Get;

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", $"Basic {_configuration.Token}");

            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Stop>>(result);
        }
    }
}
