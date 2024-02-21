using _51_lesson_EntityFramework_Intro.Infrasture;
using _51_lesson_EntityFramework_Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace _51_lesson_EntityFramework_Intro.Applications.PhoneStoreService
{
    public class PhoneStoreService : IPhoneStoreService
    {
        private ApplicationDBContext _context;

        public PhoneStoreService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<string> CreatePhoneStoreAsync(PhoneStore model)
        {
            await _context.PhoneStores.AddAsync(model);
            await _context.SaveChangesAsync();

            return "Ma'lumot yaratildi";
        }

        public async Task<List<PhoneStore>> GetAllPhoneStoreAsync()
        {
            List<PhoneStore>? item = await _context.PhoneStores.ToListAsync();

            return item;
        }

        public async Task<PhoneStore> GetPhoneStoreByIdAsync(int id)
        {
            PhoneStore? item = await _context.PhoneStores.FirstOrDefaultAsync(predicate: x => x.Id==id);

            return item!;
        }

        public async Task<string> UpdatePhoneStoreAsync(int id, PhoneStore phone)
        {
            var item = await _context.PhoneStores.FirstOrDefaultAsync(x => x.Id==id);

            if (item is not null)
            {
                item.PhoneId = phone.PhoneId;
                item.Name = phone.Name;
                item.PhoneNumber = phone.PhoneNumber;
                item.Email = phone.Email;
                item.Saller = phone.Saller;

                _context.SaveChanges();
                return "Yaratildi";
            }
            return "Yaratilmadi";
        }

        public async Task<string> DeletePhoneStoreByIdAsync(int id)
        {
            PhoneStore? result = await _context.PhoneStores.FirstOrDefaultAsync(predicate: x => x.Id == id);
            if(result is not null)
            {
                _context.PhoneStores.Remove(entity: result!);
                _context.SaveChanges();
                return "O'chirildi";
            }
            return "O'chirildi";
        }
    }
}
