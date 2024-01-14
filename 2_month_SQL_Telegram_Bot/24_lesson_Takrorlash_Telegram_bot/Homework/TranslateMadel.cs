namespace _24_lesson_Takrorlash_Telegram_bot
{
    public class Data
    {
        public List<Translation> translations { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
    }

    public class Translation
    {
        public string translatedText { get; set; }
    }
}
