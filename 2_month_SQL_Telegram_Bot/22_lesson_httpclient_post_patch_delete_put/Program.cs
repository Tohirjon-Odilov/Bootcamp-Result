namespace _22_lesson_httpclient_post_patch_delete_put
{
    public class Program
    {
        public static HttpClient SharedClient = new()
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
        };
        public static void Main(string[] args)
        {
        
        ////Lesson lesson = new Lesson();
        var comment = new Posts(SharedClient);
        }
    }
}