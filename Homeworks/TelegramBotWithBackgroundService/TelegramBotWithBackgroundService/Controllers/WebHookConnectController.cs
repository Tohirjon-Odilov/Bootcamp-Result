using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotWithBackgroundService.Bot.Services.Handlers;

namespace TelegramBotWithBackgroundService.Bot.Controllers
{
    public class WebHookConnectController : ControllerBase
    {
        private readonly BotUpdateHandler _handler;

        public WebHookConnectController(BotUpdateHandler handler, ITelegramBotClient client)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Connector([FromBody] Update update, CancellationToken cancellation)
        {
            await _handler.HandleUpdateAsync(update, cancellation);

            return Ok();
        }
    }
}
