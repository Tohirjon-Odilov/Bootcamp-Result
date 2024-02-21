using _51_lesson_EntityFramework_Intro.Models;

namespace _51_lesson_EntityFramework_Intro.Applications.PhoneStoreService
{
    public interface IPhoneStoreService
    {
        public Task<List<Phone>> GetPhones();
    }
}
