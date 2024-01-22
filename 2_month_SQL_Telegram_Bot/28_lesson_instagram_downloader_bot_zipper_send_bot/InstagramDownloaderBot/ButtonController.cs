using Telegram.Bot.Types.ReplyMarkups;

namespace _28_lesson_instagram_downloader_bot_zipper_send_bot
{
    public class ButtonController
    {
        public static ReplyKeyboardMarkup replyKeyboardMarkup = new(
            new[]
        {
            new KeyboardButton[] { "🖼 Rasm kiritish uchun bosing!" },
            new KeyboardButton[] { "🎞 Video kiritish uchun bosing!" }
        })
        {
            ResizeKeyboard = true
        };
        public static InlineKeyboardMarkup inlineKeyboard = new(new[]
{
            //First row. You can also add multiple rows.
            new []
            {
                InlineKeyboardButton.WithUrl(text: "Kanal 1", url: "https://t.me/code_en"),
                InlineKeyboardButton.WithUrl(text: "Kanal 2", url: "https://t.me/N11_Telegram")
            },
        });
    }

}
