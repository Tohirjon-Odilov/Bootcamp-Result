namespace _27_lesson_TelegramBot_keyboard_inlineKeyboard
{
    public record UserData<MessageType>
    {
        public string? Name { get; set; }
        public long? UserId { get; set; }
        public MessageType? Message { get; set; }
        public string? UserText { get; set; }
        public DateOnly? LastUsed { get; set; }
        public string? UserStartPath { get; set; }
        public string? UserZipPath { get; set; }
        public bool IsEnter { get; set; }
    }
}

//https://en.savefrom.net/1-youtube-video-downloader-556aJ/?utm_source=youtube.com&utm_medium=short_domains&utm_campaign=ssyoutube.com&a_ts=1705639023.531&url=https%3A%2F%2Fyoutube.com%2Fwatch%3Fv%3DnJTOD5jjac4
//https://en.savefrom.net/1-youtube-video-downloader-556aJ/?utm_source=youtube.com&utm_medium=short_domains&utm_campaign=ssyoutube.com&a_ts=1705637808.345&url=https%3A%2F%2Fyoutube.com%2Fwatch%3Fv%3DJtPbk7WvHAQ