using System.Text;

namespace _22_lesson_httpclient_post_patch_delete_put
{
    internal class Lesson
    {
        public Lesson()
        {
            #region Post
            //HttpClient httpClient = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Post, "https://e5c9-89-236-218-41.ngrok-free.app/Products/AddProduct");

            //request.Content = new StringContent("{\r\n  \"id\": 1909,\r\n  \"name\": \"Nima gaplar bolla\"\r\n}", Encoding.UTF8, "application/json");
            //var result = httpClient.SendAsync(request).Result;

            //var malumot = result.Content.ReadAsStringAsync().Result;

            //Console.WriteLine(malumot);
            #endregion
            #region Delete
            //using System.Text;

            //HttpClient httpClient = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Delete, "https://e5c9-89-236-218-41.ngrok-free.app/Products/DeleteProduct?id=1909");

            ////request.Content = new StringContent("{\r\n  \"id\": 1009,\r\n  \"name\": \"Nima gaplar bolla\"\r\n}", Encoding.UTF8, "application/json");
            //var result = httpClient.SendAsync(request).Result;

            //var malumot = result.Content.ReadAsStringAsync().Result;

            //Console.WriteLine(malumot);
            #endregion
            #region Put

            HttpClient httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, "https://e5c9-89-236-218-41.ngrok-free.app/Products/UpdateProduct?id=132");

            request.Content = new StringContent("{\r\n  \"id\": 132,\r\n  \"name\": \"Ha akramjon\"\r\n}", Encoding.UTF8, "application/json");
            var result = httpClient.SendAsync(request).Result;

            var malumot = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(malumot);
            #endregion
        }
    }
}
