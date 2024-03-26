using GPSTracker.API.Domain.Entities.Configurations;
using GPSTracker.API.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GPSTracker.API.Infrastructure.Broker
{
    public partial class ProGPSAPIService
    {
        private readonly URLConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _appDbContext;

        public ProGPSAPIService(
            IConfiguration configuration,
            HttpClient httpClient,
            AppDbContext appDbContext)
        {
            _configuration = configuration.GetSection("URLConfiguration").Get<URLConfiguration>();
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration.Base);
            _appDbContext = appDbContext;
        }

        public async ValueTask<int> GetDeviceIdFromNumber(string carNumber)
        {
            var device = await _appDbContext.Devices.FirstOrDefaultAsync(x => x.CarNumber == carNumber);

            if (device == null)
                throw new NotFoundException($"Device not found with this CarNumber:{carNumber}");

            return device.DeviceId;
        }
    }
}
