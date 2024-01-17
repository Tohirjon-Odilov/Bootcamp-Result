using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _26_lesson_Telegram_Bot_Group_Channel
{
    public class Server
    {
        public async Task MainServer()
        {
            TelegramBotClient botClient = new TelegramBotClient("6717197621:AAHPuty_bZTGw_ckVr00Jjln0y765Z4zkok");
            using CancellationTokenSource cts = new();
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };
            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token);
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();
            cts.Cancel();
        }
        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                if (update.Message is not { })
                    return;

                var handler = update.Type switch
                {

                    UpdateType.Message => MessageController.EssentialAsyncMessage(botClient, update, cancellationToken),
                    _ => MessageController.OtherMessage(botClient, update, cancellationToken),
                };
                await handler;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error chiqdiku => {ex.Message}");
            }

        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
