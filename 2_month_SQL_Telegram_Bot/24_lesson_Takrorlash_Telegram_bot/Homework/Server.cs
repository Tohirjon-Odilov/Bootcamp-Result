namespace _24_lesson_Takrorlash_Telegram_bot
{
    public class Server
    {
        public static async Task<string> Translate(string target, string source, string text)
        {
            Console.WriteLine("ishladi");
            #region eski api limit tugadi
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
                {
                    { "X-RapidAPI-Key", "b92c49399amshd24762e693a86cfp10bbeajsn6fa0910f8e90" },
                    { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "q", text },
                    { "target", target },
                    { "source", source },
                }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
            #endregion
        }

        public static async Task<string> DetectLanguage(string text)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2/detect"),
                Headers =
                {
                    { "X-RapidAPI-Key", "b92c49399amshd24762e693a86cfp10bbeajsn6fa0910f8e90" },
                    { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "q", text },
                }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        public static async Task<string> LanguagesCode(string target)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://google-translate1.p.rapidapi.com/language/translate/v2/languages?target={target}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "b92c49399amshd24762e693a86cfp10bbeajsn6fa0910f8e90" },
                    { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
