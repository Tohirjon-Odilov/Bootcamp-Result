using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace _22_lesson_httpclient_post_patch_delete_put
{
    internal class Todos
    {
        public Todos(HttpClient httpClient)
        {
            //var resultPost = TodosPost(httpClient).Result;
            //Console.WriteLine(resultPost);
            //var result = TodosGetAll(httpClient).Result;
            //Console.WriteLine(result);
            //var resultWithId = TodosGetById(httpClient).Result;
            //Console.WriteLine(resultWithId);
            //var resultPut = TodosPut(httpClient).Result;
            //Console.WriteLine(resultPut);
            var resultPut = TodosPatch(httpClient).Result;
            Console.WriteLine(resultPut);
            //var resultPut = TodosDelete(httpClient).Result;
            //Console.WriteLine(resultPut);
        }

        private async ValueTask<string> TodosPost(HttpClient httpClient)
        {

            using HttpResponseMessage response = await httpClient.PostAsJsonAsync("todos", new TodosMadel(userId: 9, id: 99, title: "Coder", completed: false));

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        private static async ValueTask<string> TodosGetAll(HttpClient httpClient)
        {
            var dataList = await httpClient.GetStringAsync("todos");
            return dataList;
        }
        private async Task<string> TodosGetById(HttpClient httpClient)
        {
            Console.Write("Enter comment id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using HttpResponseMessage response = await httpClient.GetAsync($"todos/{id}");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }
        private async Task<string> TodosPut(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    albumId = 3,
                    id = 2,
                    title = "Tohirjon",
                    url = "Nima gaplar bu yer update bo'ldi",
                    thumbnailUrl = "https://via.placeholder.com/160/4546546"
                }), Encoding.UTF8, "application/json"
            );

            HttpResponseMessage response = await httpClient.PutAsync($"todos/2", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> TodosPatch(HttpClient httpClient)
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

            HttpResponseMessage response = await httpClient.PatchAsync("todos/3", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> TodosDelete(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("todos/5");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }

        // qachon bo'lishi aniq bo'lsa syncron
        // qachon bo'lishi aniq bo'lmasa asyncron

    }
}
