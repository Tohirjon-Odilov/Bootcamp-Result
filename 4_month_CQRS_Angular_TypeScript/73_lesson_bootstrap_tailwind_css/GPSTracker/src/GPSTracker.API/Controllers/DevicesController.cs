using GPSTracker.API.Application.DataTransferObjects.Devices;
using GPSTracker.API.Application.Services.ClientServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GPSTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
            => _deviceService = deviceService;

        [HttpPost]
        public async ValueTask<IActionResult> PostDeviceAsync(DeviceCreationDTO deviceCreationDTO)
            => Ok(await _deviceService.AddAsync(deviceCreationDTO));

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
            => Ok(await _deviceService.RetrieveAllAsync());

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
            => Ok(await _deviceService.RetrieveByIdAsync(id));

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(DeviceModificationDTO deviceModificationDTO, int id)
            => Ok(await _deviceService.UpdateAsync(deviceModificationDTO, id));

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int id)
            => Ok(await _deviceService.DeleteAsync(id));
    }
}
