namespace _22_lesson_http_client.Homework
{
    public partial class Server
    {
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
            Console.Clear();
            return choose;
        }
    }
}
