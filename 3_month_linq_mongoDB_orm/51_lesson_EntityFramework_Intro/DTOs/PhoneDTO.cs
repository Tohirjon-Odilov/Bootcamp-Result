using Microsoft.EntityFrameworkCore;

namespace _51_lesson_EntityFramework_Intro.DTOs
{
    public class PhoneDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public int year { get; set; }
    }
}
