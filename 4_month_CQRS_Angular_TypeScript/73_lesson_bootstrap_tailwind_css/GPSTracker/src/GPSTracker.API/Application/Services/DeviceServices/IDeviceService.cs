using GPSTracker.API.Application.DataTransferObjects.Devices;
using GPSTracker.API.Domain.Entities;

namespace GPSTracker.API.Application.Services.ClientServices
{
    public interface IDeviceService
    {
        ValueTask<Device> AddAsync(DeviceCreationDTO deviceCreationDTO);
        ValueTask<List<Device>> RetrieveAllAsync();
        ValueTask<Device> RetrieveByIdAsync(int id);
        ValueTask<Device> UpdateAsync(DeviceModificationDTO deviceModificationDTO, int id);
        ValueTask<Device> DeleteAsync(int id);
    }
}
