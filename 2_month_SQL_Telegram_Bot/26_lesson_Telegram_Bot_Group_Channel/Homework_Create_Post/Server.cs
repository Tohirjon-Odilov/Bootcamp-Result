using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _26_lesson_Telegram_Bot_Group_Channel.Homework_Create_Post
{
    public class Server
    {
        public async Task MainServer()
        {
            var botClient = new TelegramBotClient("");

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
                try
                {
                    var handler = update.Type switch
                    {
                        UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken),
                        UpdateType.EditedMessage => HandleEditedMessageAsync(botClient, update, cancellationToken),
                        _ => HandleUnknownUpdateType(botClient, update, cancellationToken),
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error chiqdi:{ex.Message}");
                }
            }

            async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                var message = update.Message;
                var user = message.Chat.FirstName;
                var handler = message.Type switch
                {
                    MessageType.Text => HandleTextMessageAsync(botClient, update, cancellationToken, user),
                    MessageType.Video => HandleVideoMessageAsync(botClient, update, cancellationToken, user),
                    MessageType.VideoNote => HandleVideoNoteMessageAsync(botClient, update, cancellationToken, user),
                    MessageType.Photo => HandlePhotoMessageAsync(botClient, update, cancellationToken, user),
                    MessageType.Document => HandleDocumentMessageAsync(botClient, update, cancellationToken, user),
                    MessageType.Animation => HandleAnimationMessageAsync(botClient, update, cancellationToken, user),
                    MessageType.Sticker => HandleStickerMessageAsync(botClient, update, cancellationToken, user),
                    MessageType.Audio => HandleAudioMessageAsync(botClient, update, cancellationToken, user),
                    MessageType.Voice => HandleVoiceMessageAsync(botClient, update, cancellationToken, user),
                    MessageType.Poll => HandlePollMessageAsync(botClient, update, cancellationToken, user),
                    MessageType.Contact => HandleContactMessageAsync(botClient, update, cancellationToken, user),

                    _ => HandleUnknownMessageTypeAsync(update, update, cancellationToken),
                };
            }

            async Task HandleVideoMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
            {

                await botClient.SendPhotoAsync(
                    chatId: update.Message.Chat.Id,
                    photo: InputFile.FromUri("https://youtu.be/HafC3ayrt3U"),
                    cancellationToken: cancellationToken);
                Console.WriteLine($"Recieved Video from {user}");
            }



            async Task HandleContactMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
            {

            }



            async Task HandlePollMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
            {

            }

            async Task HandleVideoNoteMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
            {


            }

            async Task HandlePhotoMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
            {

            }


            async Task HandleStickerMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
            {

            }



            async Task HandleDocumentMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
            {

            }

            async Task HandleAnimationMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
            {

            }
            async Task HandleAudioMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
            {

            }

            async Task HandleVoiceMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
            {

            }



            async Task HandleTextMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
            {
                if (update.Message.Text == "/postcreate")
                {
                    PostCreate(botClient, update, cancellationToken);
                }

            }
            Task HandleEditedMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            async Task HandleUnknownMessageTypeAsync(Update update1, Update update2, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }



            async Task HandleUnknownUpdateType(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }


            async Task PostCreate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {


                Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Enter Channel name",
                    cancellationToken: cancellationToken);

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
