using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _27_lesson_TelegramBot_keyboard_inlineKeyboard
{
    public static class MessageController
    {
        public static bool isEnter = false;
        public static async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, UserData<Message> user)
        {
            var handler = update.Message.Type switch
            {
                MessageType.Text => TextAsyncFunction(botClient, update, cancellationToken, user),
                MessageType.Document => DocumentAsyncFunction(botClient, update, cancellationToken)
            };
        }

        private static async Task TextAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, UserData<Message> user)
        {
            var message = update.Message;
            user.Message = message;
            user.UserText = message.Text;
            user.LastUsed = new DateOnly();
            if (message.Text == "/start")
            {
                user.UserId = message.Chat.Id;

                var zipPath = CompressFile.Zip(user.UserText);
                await using Stream stream = System.IO.File.OpenRead(zipPath);

                await botClient.SendTextMessageAsync
                (
                    chatId: message.Chat.Id,
                    text: "Choose reponse",
                    replyMarkup: ButtonController.replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                );

            }
            else if (message.Text.StartsWith("C:") || message.Text.StartsWith("D:") || message.Text.StartsWith("E:")) { }
            else
            {
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "else",
                    cancellationToken: cancellationToken
                );
            }
        }

        private static async Task DocumentAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync("document");
        }

        public static async Task OtherMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync("othermessage");
        }
    }
}
