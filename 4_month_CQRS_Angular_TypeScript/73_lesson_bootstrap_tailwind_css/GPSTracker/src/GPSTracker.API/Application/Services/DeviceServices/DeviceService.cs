using GPSTracker.API.Application.DataTransferObjects.Devices;
using GPSTracker.API.Domain.Entities;
using GPSTracker.API.Domain.Exceptions;
using GPSTracker.API.Infrastructure.Repositories.DeviceRepositories;
using Mapster;

namespace GPSTracker.API.Application.Services.ClientServices
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _repository;

        public DeviceService(IDeviceRepository repository)
            => _repository = repository;

        public async ValueTask<Device> AddAsync(DeviceCreationDTO deviceCreationDTO)
        {
            var device = deviceCreationDTO.Adapt<Device>();
            var result = await _repository.InsertAsync(device);

            return result;
        }

        public async ValueTask<List<Device>> RetrieveAllAsync()
            => _repository.SelectAll();

        public async ValueTask<Device> RetrieveByIdAsync(int id)
        {
            var storageDevice = await _repository.SelectByIdAsync(id);

            if (storageDevice == null)
                throw new NotFoundException($"Device not found with this id:{id}");

            return storageDevice;
        }

        public async ValueTask<Device> UpdateAsync(DeviceModificationDTO deviceModificationDTO, int id)
        {
            var storageDevice = await _repository.SelectByIdAsync(id);

            if (storageDevice == null)
                throw new NotFoundException($"Device not found with this id:{id}");

            var updatedDevice = await _repository.UpdateAsync(storageDevice);

            return updatedDevice;
        }

        public async ValueTask<Device> DeleteAsync(int id)
        {
            var storageDevice = await _repository.SelectByIdAsync(id);

            if (storageDevice == null)
                throw new NotFoundException($"Device not found with this id:{id}");

            var removedDevice = await _repository.DeleteAsync(storageDevice);

            return removedDevice;
        }
    }
}
