using _51_lesson_EntityFramework_Intro.DTOs;
using _51_lesson_EntityFramework_Intro.Infrasture;
using _51_lesson_EntityFramework_Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace _51_lesson_EntityFramework_Intro.Applications.PhoneService
{
    public class PhoneService : IPhoneservice
    {
        private ApplicationDBContext _context;

        public PhoneService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<string> CreatePhoneAsync(Phone model)
        {
            await _context.Phones.AddAsync(model);
            await _context.SaveChangesAsync();

            return "Ma'lumot yaratildi";
        }

        public async Task<List<Phone>> GetAllPhoneAsync()
        {
            var result = await _context.Phones.ToListAsync();

            return result;
        }

        public async Task<Phone> GetPhoneByIdAsync(int id)
        {
            var result = await _context.Phones.FirstOrDefaultAsync(x => x.Id == id);

            return result ?? new Phone() { };
        }

        public async Task<string> UpdatePhoneAsync(int id, Phone model)
        {
            var result = await _context.Phones.FirstAsync(x => x.Id == id);

            if (result is not null)
            {
                result.Price = model.Price;
                result.Brand = model.Brand;
                result.Name = model.Name;
                result.year = model.year;
                _context.SaveChanges();
                return "Yaratildi";
            }
            return "Yaratilmadi";
        }
        public async Task<string> DeletePhoneByIdAsync(int id)
        {
            var phone = await _context.Phones.FirstAsync(x => x.Id == id);
            if (phone is not null)
            {
                _context.Phones.Remove(phone);
                _context.SaveChanges();
                return "Phone O'chirildi";
            }
            return "Phone O'chirilmadi";
        }
    }
}
