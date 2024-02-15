namespace _46_lesson_controller_routes.Models
{
    public record Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
    }
}
