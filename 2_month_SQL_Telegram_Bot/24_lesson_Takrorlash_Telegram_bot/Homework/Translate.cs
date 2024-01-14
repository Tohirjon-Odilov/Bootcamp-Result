using Newtonsoft.Json.Linq;

namespace _24_lesson_Takrorlash_Telegram_bot
{
    public class Translate
    {
        public Translate()
        {
            //var translatedData = Server.Translate("uz", "en", "Hello world bro").Result;
            //var data = JsonSerializer.Deserialize<Root>(translatedData);
            //Console.WriteLine(data.data.translations[0].translatedText);

            var languageDetect = Server.DetectLanguage("nima gaplar").Result;
            //Console.WriteLine(languageDetect);
            //DetectMadel detectMadel = new DetectMadel();
            //var data = JsonSerializer.Deserialize<Root>(languageDetect);
            //Console.WriteLine(data.data);

            JObject data = JObject.Parse(languageDetect);
            Console.WriteLine(data["data"]);
            //foreach (var item in data)
            //{
            //    Console.WriteLine(item[]);
            //}

            //var languagesCode = Server.LanguagesCode("uz").Result;

        }
    }
}