using Linq.Models;

namespace LINQLess.LinqMethods
{
    public class LINQForEduCenter
    {
        public List<University> GetAll()
        {
            List<University> list = new List<University>()
            {
                new University { Id = 1, Name = "Najot Ta'lim", Location = "Chilonzor", Students  =
                new List<Student>() {
                    new Student() { Id = 1, Age = 27, StudyType = "Byudjet", FirstName = "Akramjon", LastName = "Abduvahobov" },
                    new Student() { Id = 2, Age = 20, StudyType = "Kontrakt", FirstName = "Abduxoliq", LastName = "Abduxoliqov" },
                    new Student() { Id = 3, Age = 23, StudyType = "Byudjet", FirstName = "Muhammad Abdulloh", LastName = "Muhammad Abdullohov" },
                    new Student() { Id = 4, Age = 40, StudyType = "Kontrakt", FirstName = "Ikromjon", LastName = "Ikromjon" },
                } },

                new University { Id = 2, Name = "Mohir Dev", Location = "Mirzo Ulug'bek", Students  =
                new List<Student>() {
                    new Student() { Id = 1, Age = 30, StudyType = "Kontrakt", FirstName = "Akramjon Mohirdev", LastName = "Abduvahobov Mohirdev" },
                    new Student() { Id = 2, Age = 17, StudyType = "Byudjet", FirstName = "Abduxoliq Mohirdev", LastName = "Abduxoliqov Mohirdev" },
                    new Student() { Id = 3, Age = 20, StudyType = "Kontrakt", FirstName = "Muhammad Abdulloh Mohirdev", LastName = "Muhammad Abdullohov Mohirdev" },
                    new Student() { Id = 4, Age = 31, StudyType = "Kontrakt", FirstName = "Ikromjon Mohirdev", LastName = "Ikromjon Mohirdev" },
                } },
            };

            return list;
        }
        public IEnumerable<Student> GetCenterByNameWithExperience()
        {
            var result = GetAll().Where(y => y.Name == "Najot Ta'lim").SelectMany(x => x.Students).Where(z => z.StudyType == "Kontrakt");

            return result;
        }
    }
}
