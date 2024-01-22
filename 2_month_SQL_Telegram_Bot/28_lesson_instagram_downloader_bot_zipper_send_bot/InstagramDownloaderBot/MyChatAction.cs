using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _28_lesson_instagram_downloader_bot_zipper_send_bot
{
    public class MyChatAction
    {
        internal static async Task Typing(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendChatActionAsync
            (
                chatId: update.Message.Chat.Id,
                chatAction: ChatAction.Typing,
                cancellationToken: cancellationToken
            );
        }

        internal static async Task Uploading(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendChatActionAsync(
                chatId: update.Message.Chat.Id,
                chatAction: ChatAction.UploadVideo,
                cancellationToken: cancellationToken
            );
        }
    }
}
