using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace _25_lesson_TelegramBot_Basic
{
    public class Basic
    {
        private string Token { get; set; }
        public Basic(string token)
        {
            Token = token;
        }
        public async Task MessageHandler()
        {
            var botClient = new TelegramBotClient($"{Token}");

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

                var chatId = message.Chat.Id;

                Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

                // Echo received message text

                if (messageText == "/start")
                {
                    ReplyKeyboardMarkup markup =
                            new ReplyKeyboardMarkup
                                    (KeyboardButton.WithRequestContact("Contact yuborish"));
                    markup.ResizeKeyboard = true;
                    Message test = await botClient.SendTextMessageAsync(
                            chatId: 2016634633,
                            text: "Contact",
                            replyMarkup: markup
                    );
                }
                else
                {
                    //Console.WriteLine($"username: {me.Username}");
                    //Console.WriteLine($"lastname: {me.LastName}");
                    //Console.WriteLine($"id: {me.Id}");
                    Console.WriteLine();
                    Console.WriteLine($"chatId: {chatId}");
                    Console.WriteLine($"Bio: {message.Chat.Bio}");
                    Console.WriteLine($"Description: {message.Chat.Description}");
                    Console.WriteLine($"Username: {message.Chat.Username}");
                    Console.WriteLine($"LastName: {message.Chat.LastName}");
                    Console.WriteLine($"CanSetStickerSet: {message.Chat.CanSetStickerSet}");
                    Console.WriteLine($"Bio: {message.Chat.Permissions}");
                    Console.WriteLine($"joinrequest: {message.Chat.JoinByRequest}");
                    //Console.WriteLine($"Bio: {message.Chat.Bio}");
                    //Console.WriteLine($"Bio: {message.Chat.Bio}");
                    Console.WriteLine(update.ChatMember);

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
