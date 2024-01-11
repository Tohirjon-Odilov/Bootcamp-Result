namespace _22_lesson_http_client.Homework
{
    public class Server
    {
        public Server()
        {
            //Console.Write("Enter film name: ");
            //    //var film = Console.ReadLine()!;
            //    //Console.Write("Pagination: ");
            //    //var pagination = Console.ReadLine()!;
            //    Course("Spiderman", 1).Wait();

            //Result / await / Wait() ma'lumot yechadi
            var data = Omdbapi.GetAllData("Spiderman", 1).Result;
            //Console.WriteLine(data.Response);
            foreach (var item in data.Search)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}
