using System.Net;

namespace _28_lesson_instagram_downloader_bot_zipper_send_bot.InstagramDownloaderBot
{
    public class Api
    {
        public async Task<string> RunApi(string link)
        {
            string encodedUrl = WebUtility.UrlEncode(link);
            Console.WriteLine(encodedUrl);

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://instagram-downloader-download-instagram-videos-stories1.p.rapidapi.com/?url={encodedUrl}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "b92c49399amshd24762e693a86cfp10bbeajsn6fa0910f8e90" },
                    { "X-RapidAPI-Host", "instagram-downloader-download-instagram-videos-stories1.p.rapidapi.com" },
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