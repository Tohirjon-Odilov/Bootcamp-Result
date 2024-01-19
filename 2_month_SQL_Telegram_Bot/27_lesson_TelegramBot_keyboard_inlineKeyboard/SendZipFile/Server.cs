using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _27_lesson_TelegramBot_keyboard_inlineKeyboard
{
    public class Server
    {
        public HashSet<ChatId> users = new HashSet<ChatId>();
        public string? fileName = null;
        public UserData<Message> user = new UserData<Message>();
        public async Task MainServer()
        {
            TelegramBotClient botClient = new TelegramBotClient("6560962263:AAHOhhhUy6eSDvD3yVAbn7vDIFgp-b4P-Go");
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
        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                if (update.Message is not { } message)
                    return;
                Console.WriteLine($"User -> {message.Chat.FirstName} Chat Id -> {message.Chat.Id}\nMessage ->{message.Text}\n\n");

                var handler = update.Type switch
                {
                    UpdateType.Message => MessageController.HandleMessageAsync(botClient, update, cancellationToken, user),
                    //UpdateType.D=> MessageController.EssentialAsyncMessage(botClient, update, cancellationToken),
                    _ => MessageController.OtherMessage(botClient, update, cancellationToken),
                };
                await handler;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error chiqdiku => {ex.Message}");
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
