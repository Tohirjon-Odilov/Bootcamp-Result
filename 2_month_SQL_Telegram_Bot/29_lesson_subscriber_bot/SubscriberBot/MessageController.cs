using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _29_lesson_subscriber_bot
{
    public class MessageController
    {
        public Message? message;
        public Chat? chat;
        public ChatId? userId;

        public async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            message = update.Message;
            chat = message.Chat;
            userId = chat.Id;

            var handler = message.Type switch
            {
                MessageType.Text => TextAsyncFunction(botClient, update, cancellationToken),
                _ => OtherMessage(botClient, update, cancellationToken),
            };

        }

        private void TextAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task OtherMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync
            (
                chatId: userId,
                text: "Iltimos faqat matn yozing!",
                replyToMessageId: message.MessageId,
                cancellationToken: cancellationToken
            );
        }
    }
}