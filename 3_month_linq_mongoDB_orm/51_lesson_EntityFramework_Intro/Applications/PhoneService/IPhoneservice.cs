//using _51_lesson_EntityFramework_Intro.DTOs;
using _51_lesson_EntityFramework_Intro.Models;

namespace _51_lesson_EntityFramework_Intro.Applications.PhoneService
{
    public interface IPhoneservice
    {
        public Task<string> CreatePhoneAsync(Phone model);
    }
}
