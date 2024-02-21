using _51_lesson_EntityFramework_Intro.Infrasture;
using _51_lesson_EntityFramework_Intro.Models;

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
    }
}
