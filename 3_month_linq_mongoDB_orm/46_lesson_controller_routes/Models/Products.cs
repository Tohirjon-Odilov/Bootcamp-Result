namespace _46_lesson_controller_routes.Models
{
    public record Products
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;
    }
}
