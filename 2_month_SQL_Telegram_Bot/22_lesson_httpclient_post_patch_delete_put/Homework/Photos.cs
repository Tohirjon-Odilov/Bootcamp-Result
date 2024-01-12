using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace _22_lesson_httpclient_post_patch_delete_put
{
    internal class Photos
    {
        public Photos(HttpClient httpClient)
        {
            var resultPost = PhotosPost(httpClient).Result;
            Console.WriteLine(resultPost);
            //var result = PhotosGetAll(httpClient).Result;
            //Console.WriteLine(result);
            //var resultWithId = PhotosGetById(httpClient);
            //Console.WriteLine(resultWithId);
            //var resultPut = PhotosPut(httpClient).Result;
            //Console.WriteLine(resultPut)
            //var resultPut = PhotosPatch(httpClient).Result;
            //Console.WriteLine(resultPut
            //var resultPut = PhotosDelete(httpClient).Result;
            //Console.WriteLine(resultPut);
        }

        private async ValueTask<string> PhotosPost(HttpClient httpClient)
        {

            using HttpResponseMessage response = await httpClient.PostAsJsonAsync("photos", new PhotosMadel(albumId: 9, id: 99, title: "Coder", url: "https://coder.uz"));

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        private static async ValueTask<string> PhotosGetAll(HttpClient httpClient)
        {
            var dataList = await httpClient.GetStringAsync("photos");
            return dataList;
        }
        private async Task PhotosGetById(HttpClient httpClient)
        {
            Console.Write("Enter comment id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using HttpResponseMessage response = await httpClient.GetAsync($"photos/{id}");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"{jsonResponse}\n");
            //var result = await HttpMethods
        }
        private async Task<string> PhotosPut(HttpClient httpClient)
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

            HttpResponseMessage response = await httpClient.PutAsync($"photos/2", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> PhotosPatch(HttpClient httpClient)
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

            HttpResponseMessage response = await httpClient.PatchAsync("photos/3", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> PhotosDelete(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("photos/5");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }

        // qachon bo'lishi aniq bo'lsa syncron
        // qachon bo'lishi aniq bo'lmasa asyncron

    }
}
