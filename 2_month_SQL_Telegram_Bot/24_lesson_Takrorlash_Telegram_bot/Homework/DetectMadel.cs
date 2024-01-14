namespace _24_lesson_Takrorlash_Telegram_bot
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {
        public List<Detection> detections { get; set; }
    }

    public class Detection
    {
        public string language { get; set; }
        public bool isReliable { get; set; }
        public int confidence { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
    }


}
