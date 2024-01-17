using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace _26_lesson_Telegram_Bot_Group_Channel
{
    public class ButtonController
    {
        public static async Task CreateButton(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
            new List<KeyboardButton[]>()
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("Channel username update"),
                    new KeyboardButton("Post text update"),
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Image update"),
                    new KeyboardButton("Link update")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("⬅️"),
                    new KeyboardButton("Save")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Send channel")
                }
            })
            {
                ResizeKeyboard = true,
            };

            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Yaxshi, keling unda boshlaymiz...",
                replyMarkup: replyKeyboard,
                cancellationToken: cancellationToken);
        }
        public static async Task EditButtons(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
            new List<KeyboardButton[]>()
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("Edit username name"),
                    new KeyboardButton("Edit post text update"),
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Edit image"),
                    new KeyboardButton("Edit link")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("⬅️"),
                    new KeyboardButton("Edit save")
            }})
            {
                ResizeKeyboard = true,
            };

            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Yaxshi, keling davom etamiz...",
                replyMarkup: replyKeyboard,
                cancellationToken: cancellationToken);
        }
    }
}
