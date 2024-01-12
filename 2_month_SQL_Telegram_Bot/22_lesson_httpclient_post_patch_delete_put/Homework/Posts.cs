using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace _22_lesson_httpclient_post_patch_delete_put
{
    internal class Posts
    {
        public Posts(HttpClient httpClient)
        {
            var resultPost = PostsPost(httpClient).Result;
            Console.WriteLine(resultPost);
            //var result = PostsGetAll(httpClient).Result;
            //Console.WriteLine(result);
            //var resultWithId = PostsGetById(httpClient).Result;
            //Console.WriteLine(resultWithId);
            //var resultPut = PostsPut(httpClient).Result;
            //Console.WriteLine(resultPut);
            //var resultPut = PostsPatch(httpClient).Result;
            //Console.WriteLine(resultPut);
            //var resultPut = PostsDelete(httpClient).Result;
            //Console.WriteLine(resultPut);
        }

        private async ValueTask<string> PostsPost(HttpClient httpClient)
        {

            using HttpResponseMessage response = await httpClient.PostAsJsonAsync("posts", new PostsMadel(userId: 9, id: 99, title: "Coder", body: "Nima gap bolla"));

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        private static async ValueTask<string> PostsGetAll(HttpClient httpClient)
        {
            var dataList = await httpClient.GetStringAsync("posts");
            return dataList;
        }
        private async Task<string> PostsGetById(HttpClient httpClient)
        {
            Console.Write("Enter comment id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using HttpResponseMessage response = await httpClient.GetAsync($"posts/{id}");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();


            return jsonResponse;
        }
        private async Task<string> PostsPut(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    userId = 3,
                    id = 2,
                    title = "Tohirjon",
                    body = "Nima gaplar bu yer update bo'ldi"
                }), Encoding.UTF8, "application/json"
            );

            HttpResponseMessage response = await httpClient.PutAsync($"posts/2", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> PostsPatch(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    title = "patch orqali update bo'ldi",
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PatchAsync("posts/3", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> PostsDelete(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("posts/5");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }

        // qachon bo'lishi aniq bo'lsa syncron
        // qachon bo'lishi aniq bo'lmasa asyncron

    }
}
