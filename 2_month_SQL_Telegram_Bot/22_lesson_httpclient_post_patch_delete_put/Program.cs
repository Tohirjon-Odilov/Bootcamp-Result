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
            //var post = new Posts(SharedClient);
            var comment = new Comment(SharedClient);
            //var alboms = new Alboms(SharedClient);
            //var photos = new Photos(SharedClient);
            //var todo = new Todos(SharedClient);
            //var user = new Users(SharedClient);
        }
    }
}