using Telegram.Bot.Types.ReplyMarkups;

namespace _29_lesson_subscriber_bot
{
    public static class ButtonController
    {
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
