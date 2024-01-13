using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace _24_lesson_Takrorlash_Telegram_bot
{
    public partial class FirstTelegramBot
    {
        public async Task SendMessage()
        {
            var botClient = new TelegramBotClient("6346470825:AAEttuwA6pHgond5upAneuXCs6aL0N7mAS4");

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
                if (messageText == "about")
                {
                    Message sentMessage = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: $"Hello, {message.Chat.LastName}",
                        cancellationToken: cancellationToken);
                }
                else if (messageText == "sticker")
                {
                    Message sentSticker = await botClient.SendStickerAsync(
                        chatId: chatId,
                        sticker: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"),
                        cancellationToken: cancellationToken);
                }
                else if (messageText == "video")
                {
                    Message sentVideo = await botClient.SendVideoAsync(
                        chatId: chatId,
                        video: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/video-bulb.mp4"),
                        cancellationToken: cancellationToken);
                }
                else if (messageText == "markdown")
                {
                    Message markDown = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Trying *all the parameters* of `sendMessage` method",
                        parseMode: ParseMode.MarkdownV2,
                        disableNotification: false,
                        replyToMessageId: update.Message.MessageId,
                        replyMarkup: new InlineKeyboardMarkup(
                            InlineKeyboardButton.WithUrl(
                                text: "Check sendMessage method",
                                url: "https://core.telegram.org/bots/api#sendmessage")),
                        cancellationToken: cancellationToken);
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
