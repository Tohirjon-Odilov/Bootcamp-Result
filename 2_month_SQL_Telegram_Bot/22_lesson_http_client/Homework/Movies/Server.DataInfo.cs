namespace _22_lesson_http_client.Homework
{
    public partial class Server
    {
        public void SingleDataInfo(DataInfoMadel singleData) 
        {
            Console.Clear();
            Console.WriteLine($"\n  About '{singleData.Title}' film");
            Console.WriteLine($"\n  Created in: {singleData.Year} year ");
            Console.WriteLine($"\n  Released: {singleData.Released} ");
            Console.WriteLine($"\n  Film duration: {singleData.Released} ");
            Console.WriteLine($"\n  Genre: {singleData.Genre} ");
            Console.WriteLine($"\n  Film director: {singleData.Director} ");
            Console.WriteLine($"\n  Director: {singleData.Director} ");
            Console.WriteLine($"\n  Writer: {singleData.Writer} ");
            Console.WriteLine($"\n  Syujet: {singleData.Plot} ");
            Console.WriteLine($"\n  Language: {singleData.Language} ");
            Console.WriteLine($"\n  Country: {singleData.Country} ");
            Console.WriteLine($"\n  Awards: {singleData.Awards} ");
            Console.ReadKey();
        }
    }
}
