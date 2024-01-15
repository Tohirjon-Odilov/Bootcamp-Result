using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _25_lesson_TelegramBot_Basic
{
    public partial class Basic
    {
        private string Token { get; set; }
        public Basic(string token)
        {
            Token = token;
        }
        private long chatId { get; set; }
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

                var handler = update.Type switch
                {
                    UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken),
                    //UpdateType.EditedMessage => HandleEditedMessageAsync(botClient, update, cancellationToken),
                    //UpdateType.EditedChannelPost => HandleEditedChannelPostAsync(botClient, update, cancellationToken),
                    //UpdateType.ChannelPost => HandleChannelPostAsync(botClient, update, cancellationToken),
                    //UpdateType.Poll => HandlePollAsync(botClient, update, cancellationToken),
                    //UpdateType.PollAnswer => HandlePollAnswerAsync(botClient, update, cancellationToken),
                    //UpdateType.MyChatMember => HandleMyChatMemberAsync(botClient, update, cancellationToken),
                    _ => HandleMessageAsync(botClient, update, cancellationToken),
                };

                try
                {
                    await handler;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error chiqdi:{ex.Message}");
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

            async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                // Only process Message updates: https://core.telegram.org/bots/api#message
                if (update.Message is not { } message)
                    return;
                // Only process text messages
                if (message.Text is not { } messageText)
                    return;
                Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

                var handler = message.Type switch
                {
                    MessageType.Text => HandleTextMessageAsync(botClient, update, cancellationToken),
                    MessageType.Video => HandleVideoMessageAsync(botClient, update, cancellationToken),
                    MessageType.Audio => HandleAudioMessageAsync(botClient, update, cancellationToken),
                    MessageType.Sticker => HandleStickerMessageAsync(botClient, update, cancellationToken),
                    MessageType.Photo => HandlePhotoMessageAsync(botClient, update, cancellationToken),
                    MessageType.Contact => HandleContactMessageAsync(botClient, update, cancellationToken),
                    MessageType.Document => HandleDocumentMessageAsync(botClient, update, cancellationToken),
                    MessageType.Location => HandleLocationMessageAsync(botClient, update, cancellationToken),
                    MessageType.Poll => HandlePollMessageAsync(botClient, update, cancellationToken),
                    MessageType.Voice => HandleVoiceMessageAsync(botClient, update, cancellationToken),
                    MessageType.MessagePinned => HandleMessagePinnedMessageAsync(botClient, update, cancellationToken),

                    _ => HandleUnknownMessageTypeAsync(botClient, update, cancellationToken),
                };
            }
        }
    }
}
