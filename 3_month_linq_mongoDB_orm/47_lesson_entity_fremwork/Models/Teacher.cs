namespace _47_lesson_entity_fremwork.Models
{
    public record Teacher
    {
        public int teacher_id { get; set; }
        public string full_name { get; set; }
        public int age { get; set; }
        public string salary { get; set; }
        public string phone { get; set; }
        public int groups_count { get; set; }
        public int experience { get; set; }
    }
}
