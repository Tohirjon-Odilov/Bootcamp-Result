using Telegram.Bot;

namespace _24_lesson_Takrorlash_Telegram_bot
{
    public partial class FirstTelegramBot
    {
        public async Task FirstMessage()
        {
            var botClient = new TelegramBotClient("6814085088:AAEiOlIocad539Prf9MWiMv5cFzqB1nE8WQ");

            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
        }
    }
}
