using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace _22_lesson_httpclient_post_patch_delete_put
{
    internal class Comment
    {
        public Comment(HttpClient httpClient)
        {
            //var resultPost = CommentPost(httpClient).Result;
            //Console.WriteLine(resultPost);
            //var result = CommentGetAll(httpClient).Result;
            //Console.WriteLine(result);
            //var resultWithId = CommentGetById(httpClient);
            //Console.WriteLine(resultWithId);
            //var resultPut = CommentPut(httpClient).Result;
            //Console.WriteLine(resultPut)
            //var resultPut = CommentPatch(httpClient).Result;
            //Console.WriteLine(resultPut
            var resultPut = CommentDelete(httpClient).Result;
            Console.WriteLine(resultPut);
        }

        // _____init_____ faqatgina constructor vaqtida qiymat biriktira olamiz qolgan vaqt readonly bo'ladi.
        private async ValueTask<string> CommentPost(HttpClient httpClient)
        {
            #region boshqa
            //using StringContent jsonContent = new
            //    (
            //        JsonSerializer.Serialize(new
            //        {
            //            postId = 3,
            //            id = 1,
            //            name = "Coder",
            //            email = "coder@gmail.com",
            //            body = "Nima gaplar olamda"
            //        }), Encoding.UTF8, "application/json"
            //    );

            //string jsonResult = await jsonContent.ReadAsStringAsync();
            #endregion

            using HttpResponseMessage response = await httpClient.PostAsJsonAsync("todos", new CommentMadel(postId: 9, id: 99, name: "Coder", email: "coder@gmail.com", body: "Nima gap bolla"));

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        private static async ValueTask<string> CommentGetAll(HttpClient httpClient)
        {
            var dataList = await httpClient.GetStringAsync("comments");
            return dataList;
        }
        private async Task CommentGetById(HttpClient httpClient) 
        {
            Console.Write("Enter comment id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using HttpResponseMessage response = await httpClient.GetAsync($"comments/{id}");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"{jsonResponse}\n");
            //var result = await HttpMethods
        }
        private async Task<string> CommentPut(HttpClient httpClient)
        {
            using StringContent jsonContent = new
                (
                    JsonSerializer.Serialize(new
                    {
                        postId = 3,
                        id = 2,
                        name = "Tohirjon",
                        email = "coder@gmail.com",
                        body = "Nima gaplar bu yer update bo'ldi"
                    }), Encoding.UTF8, "application/json"
                );

            HttpResponseMessage response = await httpClient.PutAsync($"comments/2", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> CommentPatch(HttpClient httpClient)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    name = "patch orqali update bo'ldi",
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await httpClient.PatchAsync("comments/3", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> CommentDelete(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("comments/5");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }

        // qachon bo'lishi aniq bo'lsa syncron
        // qachon bo'lishi aniq bo'lmasa asyncron

    }
}
