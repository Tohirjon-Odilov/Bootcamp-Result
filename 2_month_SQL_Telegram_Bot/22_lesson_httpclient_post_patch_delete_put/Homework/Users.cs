using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace _22_lesson_httpclient_post_patch_delete_put
{
    internal class Users
    {
        public Users(HttpClient httpClient)
        {
            //var resultPost = UsersPost(httpClient).Result;
            //Console.WriteLine(resultPost);
            //var result = UsersGetAll(httpClient).Result;
            //Console.WriteLine(result);
            //var resultWithId = UsersGetById(httpClient).Result;
            //Console.WriteLine(resultWithId);
            //var resultPut = UsersPut(httpClient).Result;
            //Console.WriteLine(resultPut);
            //var resultPut = UsersPatch(httpClient).Result;
            //Console.WriteLine(resultPut);
            var resultPut = UsersDelete(httpClient).Result;
            Console.WriteLine(resultPut);
        }

        private async ValueTask<string> UsersPost(HttpClient httpClient)
        {

            using HttpResponseMessage response = await httpClient.PostAsJsonAsync("users", new UsersMadel(id: 9, name: "Tohirjon", username: "Coder", email: "coder@gmail.com", address: "Tashkent", phone: "99 899 88 99",website: "https://coder.uz", company: "Najot ta'lim"));

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        private static async ValueTask<string> UsersGetAll(HttpClient httpClient)
        {
            var dataList = await httpClient.GetStringAsync("users");
            return dataList;
        }
        private async Task<string> UsersGetById(HttpClient httpClient)
        {
            Console.Write("Enter comment id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using HttpResponseMessage response = await httpClient.GetAsync($"users/{id}");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return jsonResponse;
        }
        private async Task<string> UsersPut(HttpClient httpClient)
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

            HttpResponseMessage response = await httpClient.PutAsync($"users/2", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> UsersPatch(HttpClient httpClient)
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

            HttpResponseMessage response = await httpClient.PatchAsync("users/3", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> UsersDelete(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("users/5");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }

        // qachon bo'lishi aniq bo'lsa syncron
        // qachon bo'lishi aniq bo'lmasa asyncron

    }
}
