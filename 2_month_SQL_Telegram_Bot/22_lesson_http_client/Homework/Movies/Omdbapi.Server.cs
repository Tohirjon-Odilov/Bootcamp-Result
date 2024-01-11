using System.ComponentModel.Design;

namespace _22_lesson_http_client.Homework
{
    public partial class Server
    {
        public ResponseData AllData { get; set; }
        public DataInfoMadel SingleData { get; set; }
        public Server()
        {
            //Console.Write("Enter film name: ");
            //    //var film = Console.ReadLine()!;
            //    //Console.Write("Pagination: ");
            //    //var pagination = Console.ReadLine()!;
            //    Course("Spiderman", 1).Wait();

            //Result / await / Wait() ma'lumot yechadi

            AllData = Omdbapi.GetAllData("Batman", 1).Result;
            //var data1 = Omdbapi.GetAllData("Spiderman", 2).Result;

            int choose = 0;
            while (true)
            {
                for (int i = 0; i < AllData.Search.Count; i++)
                {
                    if (choose == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(AllData.Search[choose].Title);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(AllData.Search[i].Title);
                    }

                }
                choose = UserSelected(Console.ReadKey().Key,choose);
            }
        }
        public int UserSelected(ConsoleKey key, int choose)
        {
            Console.Clear();
            string ConvertedKey = Convert.ToString(key)!;
            if (ConvertedKey == "UpArrow")
            {
                if (choose <= -1)
                {
                    choose = AllData.Search.Count - 1;

                }
                else if (choose == 0) choose = AllData.Search.Count;
                return --choose;
            }
            else if (ConvertedKey == "DownArrow")
            {
                if (choose == AllData.Search.Count - 1)
                {
                    choose = -1;
                }
                return ++choose;
            }
            else if (ConvertedKey == "Enter")
            {
                SingleData = Omdbapi.GetDataInfo(AllData.Search[choose].imdbID).Result;
                SingleDataInfo(SingleData);
            }
            return choose; 
        }
    }
}
