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
                var handler = update.Type switch
                {
                    UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken),
                    UpdateType.EditedMessage => HandleEditedMessageAsync(botClient, update, cancellationToken),
                    _ => HandleUnknownUpdateType(botClient, update, cancellationToken),
                };

                try
                {
                    await handler;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error chiqdi:{ex.Message}");
                }

                // Echo received message text

                //if (messageText == "/start")
                //{
                //    ReplyKeyboardMarkup markup =
                //            new ReplyKeyboardMarkup
                //                    (KeyboardButton.WithRequestContact("Contact yuborish"));
                //    markup.ResizeKeyboard = true;
                //    Message test = await botClient.SendTextMessageAsync(
                //            chatId: 2016634633,
                //            text: "Contact",
                //            replyMarkup: markup
                //    );
                //}
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

        private object HandleUnknownUpdateType(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private object HandleEditedMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private object HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
