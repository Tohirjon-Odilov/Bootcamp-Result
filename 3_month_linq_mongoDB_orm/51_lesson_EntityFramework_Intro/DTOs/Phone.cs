using Microsoft.EntityFrameworkCore;

namespace _51_lesson_EntityFramework_Intro.DTOs
{
    [Keyless]
    public class Phone
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Price { get; set; }
        public int year { get; set; }
    }
}
