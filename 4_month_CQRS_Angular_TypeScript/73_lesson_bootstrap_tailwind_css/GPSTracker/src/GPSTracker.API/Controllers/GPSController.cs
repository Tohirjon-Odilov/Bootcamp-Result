using GPSTracker.API.Infrastructure.Broker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GPSTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class GPSController : ControllerBase
    {
        private readonly ProGPSAPIService _gpsService;

        public GPSController(ProGPSAPIService gpsService)
            => _gpsService = gpsService;

        [HttpGet]
        public async Task<IActionResult> GetEvents(DateTime fromDate, DateTime toDate, string carNumber)
        {
            return Ok(await _gpsService.GetEvents(fromDate, toDate, carNumber));
        }

        [HttpGet]
        public async Task<IActionResult> GetRoute(DateTime fromDate, DateTime toDate, string carNumber)
        {
            return Ok(await _gpsService.GetRoute(fromDate, toDate, carNumber));
        }

        [HttpGet]
        public async Task<IActionResult> GetStops(DateTime fromDate, DateTime toDate, string carNumber)
        {
            return Ok(await _gpsService.GetStops(fromDate, toDate, carNumber));
        }

        [HttpGet]
        public async Task<IActionResult> GetSummary(DateTime fromDate, DateTime toDate, string carNumber)
        {
            return Ok(await _gpsService.GetSummary(fromDate, toDate, carNumber));
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips(DateTime fromDate, DateTime toDate, string carNumber)
        {
            return Ok(await _gpsService.GetTrips(fromDate, toDate, carNumber));
        }
    }
}
