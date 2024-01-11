using System.Text.Json;

namespace _22_lesson_http_client.Homework.Currency
{
    public class NationalBankUzbekistan
    {
        public NationalBankUzbekistan()
        {
            Console.Write("Enter currency: ");
            string currency = Console.ReadLine()!;
            Console.Write("Enter value: ");
            int value = Convert.ToInt32(Console.ReadLine());

            Course(currency, value).Wait();
        }
        public static async Task Course(string currency, int value)
        {
            HttpClient httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://nbu.uz/exchange-rates/json/");
            var response = await httpClient.SendAsync(request);
            string Body = await response.Content.ReadAsStringAsync();
            var courses = JsonSerializer.Deserialize<List<Valyuta>>(Body)!;

            foreach (var item in courses)
            {
                if (item.code == currency)
                {
                    var CurrencyValue = Convert.ToDecimal(item.cb_price);
                    Console.WriteLine($"{value}{currency} => {CurrencyValue * value}UZS");
                    return;
                }
            }
        }
    }
}
