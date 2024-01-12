﻿using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace _22_lesson_httpclient_post_patch_delete_put
{
    internal class Alboms
    {
        public Alboms(HttpClient httpClient)
        {
            var resultPost = AlbomsPost(httpClient).Result;
            Console.WriteLine(resultPost);
            //var result = AlbomsGetAll(httpClient).Result;
            //Console.WriteLine(result);
            //var resultWithId = AlbomsGetById(httpClient);
            //Console.WriteLine(resultWithId);
            //var resultPut = AlbomsPut(httpClient).Result;
            //Console.WriteLine(resultPut)
            //var resultPut = AlbomsPatch(httpClient).Result;
            //Console.WriteLine(resultPut
            //var resultPut = AlbomsDelete(httpClient).Result;
            //Console.WriteLine(resultPut);
        }

        private async ValueTask<string> AlbomsPost(HttpClient httpClient)
        {

            using HttpResponseMessage response = await httpClient.PostAsJsonAsync("albums", new AlbomsMadel(userId: 9, id: 99, title: "Coder", body: "Nima gap bolla"));

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        private static async ValueTask<string> AlbomsGetAll(HttpClient httpClient)
        {
            var dataList = await httpClient.GetStringAsync("alboms");
            return dataList;
        }
        private async Task AlbomsGetById(HttpClient httpClient)
        {
            Console.Write("Enter comment id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using HttpResponseMessage response = await httpClient.GetAsync($"alboms/{id}");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"{jsonResponse}\n");
            //var result = await HttpMethods
        }
        private async Task<string> AlbomsPut(HttpClient httpClient)
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

            HttpResponseMessage response = await httpClient.PutAsync($"alboms/2", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> AlbomsPatch(HttpClient httpClient)
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

            HttpResponseMessage response = await httpClient.PatchAsync("alboms/3", jsonContent);

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
        public static async ValueTask<string> AlbomsDelete(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("alboms/5");

            response.EnsureSuccessStatusCode().WriteRequestToConsole();

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }

        // qachon bo'lishi aniq bo'lsa syncron
        // qachon bo'lishi aniq bo'lmasa asyncron

    }
}
