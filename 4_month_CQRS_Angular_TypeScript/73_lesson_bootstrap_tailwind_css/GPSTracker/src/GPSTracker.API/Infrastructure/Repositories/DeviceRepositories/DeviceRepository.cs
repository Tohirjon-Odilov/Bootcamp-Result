using GPSTracker.API.Domain.Entities;

namespace GPSTracker.API.Infrastructure.Repositories.DeviceRepositories
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
