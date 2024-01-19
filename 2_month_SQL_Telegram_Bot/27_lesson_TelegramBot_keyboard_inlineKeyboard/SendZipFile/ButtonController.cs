using Telegram.Bot.Types.ReplyMarkups;

namespace _27_lesson_TelegramBot_keyboard_inlineKeyboard
{
    public static class ButtonController
    {
        public static ReplyKeyboardMarkup replyKeyboardMarkup = new(
            new[]
        {
            new KeyboardButton[] { "Path kiriting" }
        })
        {
            ResizeKeyboard = true
        };
    }
}
