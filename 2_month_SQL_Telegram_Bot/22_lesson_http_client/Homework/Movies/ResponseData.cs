namespace _22_lesson_http_client.Homework
{
    public class ResponseData
    {
        public List<MovieMadel> Search { get; set; } = new List<MovieMadel>();
        public string totalResults { get; set; } = String.Empty;
        public string Response { get; set; } = String.Empty;
    }
}
