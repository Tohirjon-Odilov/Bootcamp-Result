using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRWebpack.Hubs;

namespace Notifications.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<ChatHub> hubContext;

        public NotificationController(IHubContext<ChatHub> hubContext) 
            => this.hubContext = hubContext;

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] string message)
        {
            await hubContext.Clients.All.SendAsync("ReceiveNotification", message);
            return Ok();
        }
    }
}
