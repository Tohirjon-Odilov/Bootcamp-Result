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
    }
}
