using System.ComponentModel.DataAnnotations;

namespace _51_lesson_EntityFramework_Intro.Models
{
    public class PhoneStore
    {
        public int Id { get; set; }
        public int PhoneId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Saller { get; set; } = string.Empty;
    }
}
