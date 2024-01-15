using Telegram.Bot;
using Telegram.Bot.Types;

namespace _25_lesson_TelegramBot_Basic
{
    public partial class Basic
    {
        private async Task HandleEditedMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Message sendMessage = await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                text: message.Text,
                cancellationToken: cancellationToken
                );
        }

        //private Task HandleEditedChannelPostAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //private Task HandleChannelPostAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //private Task HandlePollAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //private Task HandlePollAnswerAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //private Task HandleMyChatMemberAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //private Task HandleUnknownUpdateType(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
