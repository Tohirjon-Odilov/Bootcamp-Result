using _51_lesson_EntityFramework_Intro.DTOs;
using _51_lesson_EntityFramework_Intro.Models;

namespace _51_lesson_EntityFramework_Intro.Applications.PhoneService
{
    public interface IPhoneservice
    {
        public Task<string> CreatePhoneAsync(Phone model);
        public Task<List<Phone>> GetAllPhoneAsync();
        public Task<Phone> GetPhoneByIdAsync(int id);
        public Task<string> UpdatePhoneAsync(int id, Phone model);
        public Task<string> DeletePhoneByIdAsync(int id);
    }
}
