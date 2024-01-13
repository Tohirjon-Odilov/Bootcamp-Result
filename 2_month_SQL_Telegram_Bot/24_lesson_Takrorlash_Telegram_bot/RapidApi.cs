namespace _24_lesson_Takrorlash_Telegram_bot
{
    internal class RapidApi
    {
        public async Task Api()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://dictionary-by-api-ninjas.p.rapidapi.com/v1/dictionary?word=bright"),
                Headers =
    {
        { "X-RapidAPI-Key", "b92c49399amshd24762e693a86cfp10bbeajsn6fa0910f8e90" },
        { "X-RapidAPI-Host", "dictionary-by-api-ninjas.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}
