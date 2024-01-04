namespace _18_Lesson_Json.Task
{
    public class BaseModul
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string UserName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public Address Address { get; set; }
        public string Phone { get; set; } = String.Empty;
        public string Website { get; set; } = String.Empty;
        public Company Company { get; set; }
        public Location Location { get; set; }
    }
}
