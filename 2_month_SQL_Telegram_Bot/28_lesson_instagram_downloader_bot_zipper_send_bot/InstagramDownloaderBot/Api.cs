using System.Net;

namespace _28_lesson_instagram_downloader_bot_zipper_send_bot
{
    public class Api
    {
        public async Task<string> RunApi(string link)
        {
            string encodedUrl = WebUtility.UrlEncode(link);
            Console.WriteLine(encodedUrl);

            var client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://instagram-downloader-download-instagram-videos-stories1.p.rapidapi.com/?url={encodedUrl}"),
                Headers =
                    {
                        { "X-RapidAPI-Key",  "f927051de5msh33c089150223b61p1e384ajsn0b24f85919fd"},
                        { "X-RapidAPI-Host", "instagram-downloader-download-instagram-videos-stories1.p.rapidapi.com" },
                    },
            };

            using (var response = await client.SendAsync(request))
            {
                // qancha limit qolganini ko'rsa bo'ladi
                foreach (var item in response.Headers)
                {
                    if (item.Key == "X-RateLimit-Requests-Remaining")
                    {
                        Console.WriteLine(item.Value.ToList()[0]);
                    }
                }

                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();

                return body;
            }
        }
    }
}