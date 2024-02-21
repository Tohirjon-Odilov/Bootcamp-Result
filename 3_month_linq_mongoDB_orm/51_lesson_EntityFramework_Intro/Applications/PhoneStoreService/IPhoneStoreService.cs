using _51_lesson_EntityFramework_Intro.Models;

namespace _51_lesson_EntityFramework_Intro.Applications.PhoneStoreService
{
    public interface IPhoneStoreService
    {
        public Task<string> CreatePhoneStoreAsync(PhoneStore phoneStore);
        public Task<List<PhoneStore>> GetAllPhoneStoreAsync();
        public Task<PhoneStore> GetPhoneStoreByIdAsync(int id);
        public Task<string> UpdatePhoneStoreAsync(int id, PhoneStore phone);
        public Task<string> DeletePhoneStoreByIdAsync(int id);
    }
}
