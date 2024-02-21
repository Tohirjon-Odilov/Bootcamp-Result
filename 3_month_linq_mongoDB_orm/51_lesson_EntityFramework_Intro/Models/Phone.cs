namespace _51_lesson_EntityFramework_Intro.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public int year { get; set; }
    }
}
