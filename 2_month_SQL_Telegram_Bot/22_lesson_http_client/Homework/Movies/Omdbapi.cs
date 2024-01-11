using _22_lesson_http_client.Homework;
using System.Text.Json;

//https://www.omdbapi.com/?apikey=6577cabc&s=Spiderman&page=1
namespace _22_lesson_http_client.Homework
{
    public class Omdbapi
    {
        //public Omdbapi()
        //{
        //    //Console.Write("Enter film name: ");
        //    //var film = Console.ReadLine()!;
        //    //Console.Write("Pagination: ");
        //    //var pagination = Console.ReadLine()!;
        //    Course("Spiderman", 1).Wait();
        //}
        public static async Task<ResponseData> GetAllData(string film, int pagination)
        {
            HttpClient httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://www.omdbapi.com/?apikey=6577cabc&s={film}&page={pagination}");
            var response = await httpClient.SendAsync(request);
            string Body = await response.Content.ReadAsStringAsync();
            ResponseData responseData = JsonSerializer.Deserialize<ResponseData>(Body)!;
            //Console.WriteLine(responseData);
            return responseData;
            //Console.WriteLine(JsonSerializer.Deserialize<List<List<Movie>>>(Body));
            //Console.WriteLine(courses.Search);
            //Console.WriteLine(courses.totalResults);
        }
        public static async Task<DataInfoMadel> GetDataInfo(string imdbApi)
        {
            HttpClient httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://www.omdbapi.com/?i={imdbApi}&plot=full&apikey=6577cabc");
            var response = await httpClient.SendAsync(request);
            string body = await response.Content.ReadAsStringAsync();
            DataInfoMadel responseData = JsonSerializer.Deserialize<DataInfoMadel>(body)!;
            return responseData;
        }
    }
}
