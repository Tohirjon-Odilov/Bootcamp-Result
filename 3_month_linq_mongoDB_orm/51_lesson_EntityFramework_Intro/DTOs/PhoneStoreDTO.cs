using System.ComponentModel.DataAnnotations;

namespace _51_lesson_EntityFramework_Intro.DTOs
{
    public class PhoneStoreDTO
    {
        public int PhoneId { get; set; }
        public string Name { get; set; } = string.Empty;
        [RegularExpression(@"((\(\d{2}\) ?)|(\d{2}-))?\d{3}-\d{2}-\d{2}", ErrorMessage = "Invalid Phone Number!")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Saller { get; set; } = string.Empty;
    }
}
