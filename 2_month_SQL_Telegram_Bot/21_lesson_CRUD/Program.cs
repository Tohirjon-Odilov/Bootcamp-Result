
//using System.Net.Http;

//namespace LEssonClients
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {

//            GetAsync();
//        }


//        //static async void GetExchange()
//        //{
//        //    HttpClient httpClient = new HttpClient();
//        //    string apiUrl = "https://jsonplaceholder.typicode.com/posts";
//        //    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

//        //    if (response.IsSuccessStatusCode)
//        //    {
//        //        string responseContent = await response.Content.ReadAsStringAsync();
//        //        // Process the response data here

//        //        Console.WriteLine(responseContent);
//        //    }
//        //}


//        ////private static HttpClient sharedClient = new()
//        ////{
//        ////    BaseAddress = new Uri("https://nbu.uz/uz/exchange-rates/json"),
//        ////};

//        static async Task GetAsync(HttpClient httpClient)
//        {
//            using HttpResponseMessage response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

//            response.EnsureSuccessStatusCode();

//            var jsonResponse = await response.Content.ReadAsStringAsync();
//            Console.WriteLine($"{jsonResponse}\n");

//            // Expected output:
//            //   GET https://jsonplaceholder.typicode.com/todos/3 HTTP/1.1
//            //   {
//            //     "userId": 1,
//            //     "id": 3,
//            //     "title": "fugiat veniam minus",
//            //     "completed": false
//            //   }
//        }


//    }
//}
using System.Text.Json;
using static _21_lesson_CRUD.Valyuta;

internal class Program
{
    static async Task Main(string[] args)
    {
        HttpClient httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "https://nbu.uz/exchange-rates/json/");
        var response = await httpClient.SendAsync(request);
        var body = await response.Content.ReadAsStringAsync();
        Console.WriteLine(body);
        var courses = JsonSerializer.Deserialize<List<Root>>(body)!;
        foreach (var c in courses)
        {
            Console.WriteLine(c.title);
        }
    }
}