using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _28_lesson_instagram_downloader_bot_zipper_send_bot
{
    public class Server
    {
        public string Token { get; set; }
        public string VideoLink { get; private set; }

        public Server(string token)
        {
            this.Token = token;
        }
        public async Task Run()
        {

            var botClient = new TelegramBotClient($"{this.Token}");

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

        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                if (update.Message is not { } message)
                    return;
                Console.WriteLine($"User -> {message.Chat.FirstName} Chat Id -> {message.Chat.Id}\nMessage ->{message.Text}\n\n");
                MessageController messageController = new MessageController();
                var handler = update.Type switch
                {
                    UpdateType.Message => messageController.HandleMessageAsync(botClient, update, cancellationToken),
                    //UpdateType.D=> messageController.EssentialAsyncMessage(botClient, update, cancellationToken),
                    _ => messageController.OtherMessage(botClient, update, cancellationToken),
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error chiqdiku => {ex.Message}");
            }
        }
        public async Task<Task> HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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
