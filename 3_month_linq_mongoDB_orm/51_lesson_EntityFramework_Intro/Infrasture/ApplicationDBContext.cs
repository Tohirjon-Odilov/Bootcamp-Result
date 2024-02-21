//using _51_lesson_EntityFramework_Intro.DTOs;
using _51_lesson_EntityFramework_Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace _51_lesson_EntityFramework_Intro.Infrasture
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {}
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneStore> PhoneStores { get; set; }
    }
}
