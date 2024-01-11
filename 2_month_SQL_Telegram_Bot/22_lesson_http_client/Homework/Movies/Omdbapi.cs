using _22_lesson_http_client.Homework.Movies;
using System.Text.Json;

//https://www.omdbapi.com/?apikey=6577cabc&s=Spiderman&page=1
namespace _22_lesson_http_client.Homework
{
    internal class Omdbapi
    {
        public Omdbapi()
        {
            Console.Write("Enter film name: ");
            var film = Console.ReadLine()!;
            Course(film, 1).Wait();
        }
        public static async Task Course(string film, int value)
        {
            HttpClient httpClient = new HttpClient(); 
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://www.omdbapi.com/?apikey=ed7b702d&s={film}&page=1");
            var response = await httpClient.SendAsync(request);
            string Body = await response.Content.ReadAsStringAsync();
            var courses = JsonSerializer.Deserialize<FullData>(Body)!;
            //Console.WriteLine(JsonSerializer.Deserialize<List<List<Movie>>>(Body));
            Console.WriteLine(courses.Search);
            Console.WriteLine(courses.totalResults);
        }
    }
}
