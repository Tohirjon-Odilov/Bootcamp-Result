using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
namespace _26_lesson_Telegram_Bot_Group_Channel
{
    public class LinkGroupChannel
    {
        public async Task ReplayMessage()
        {
            var botClient = new TelegramBotClient("6814085088:AAEiOlIocad539Prf9MWiMv5cFzqB1nE8WQ");

            using CancellationTokenSource cts = new();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                // Only process Message updates: https://core.telegram.org/bots/api#message
                if (update.Message is not { } message)
                    return;
                // Only process text messages
                if (message.Text is not { } messageText)
                    return;

                try
                {
                    var chatId = message.Chat.Id;

                    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

                    // Echo received message text
                    Message sentMessage = await botClient.SendTextMessageAsync(
                        chatId: "@N11_Telegram",
                        text: "You said:\n" + messageText,
                        cancellationToken: cancellationToken);
                }
                catch (Exception ex)
                {
                    throw new Exception("salo " + ex);
                }
            }

            Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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
}
