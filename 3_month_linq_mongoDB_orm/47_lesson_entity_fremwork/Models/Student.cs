namespace _47_lesson_entity_fremwork.Models
{
    public record Student
    {
        public int student_id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public int age { get; set; }
        public int course_id { get; set; }
        public string phone { get; set; }
        public string parent_phone { get; set; }
        public string shot_number { get; set; }
    }
}
