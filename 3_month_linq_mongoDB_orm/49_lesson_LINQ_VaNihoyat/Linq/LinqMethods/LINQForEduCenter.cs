using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq.Models;

namespace LINQLess.LinqMethods
{
    public class LINQForEduCenter
    {
        public List<EduCenter> GetAll()
        {
            List<EduCenter> list = new List<EduCenter>()
            {
                new EduCenter { Id = 1, Name = "Najot Ta'lim", Location = "Chilonzor", Employees  =
                new List<Employee>() {
                    new Employee() { Id = 1, Age = 27, Experience = 4, FirstName = "Akramjon", LastName = "Abduvahobov" },
                    new Employee() { Id = 2, Age = 20, Experience = 3, FirstName = "Abduxoliq", LastName = "Abduxoliqov" },
                    new Employee() { Id = 3, Age = 23, Experience = 1, FirstName = "Muhammad Abdulloh", LastName = "Muhammad Abdullohov" },
                    new Employee() { Id = 4, Age = 40, Experience = 15, FirstName = "Ikromjon", LastName = "Ikromjon" },
                } },
                new EduCenter { Id = 2, Name = "Mohir Dev", Location = "Mirzo Ulug'bek", Employees  =
                new List<Employee>() {
                    new Employee() { Id = 1, Age = 30, Experience = 10, FirstName = "Akramjon Mohirdev", LastName = "Abduvahobov Mohirdev" },
                    new Employee() { Id = 2, Age = 17, Experience = 6, FirstName = "Abduxoliq Mohirdev", LastName = "Abduxoliqov Mohirdev" },
                    new Employee() { Id = 3, Age = 20, Experience = 9, FirstName = "Muhammad Abdulloh Mohirdev", LastName = "Muhammad Abdullohov Mohirdev" },
                    new Employee() { Id = 4, Age = 31, Experience = 2, FirstName = "Ikromjon Mohirdev", LastName = "Ikromjon Mohirdev" },
                } },

            };

            return list;
        }

        public IEnumerable<string> GetAllCenter()
        {
            var centers = GetAll().Select(x => x.Name);

            return centers;
        }

        public IEnumerable<EduCenter> GetCenterByName(string name)
        {
            var centers = GetAll().Select(x => x).Where(z => z.Name == name);

            return centers;
        }

        public IEnumerable<Employee> GetCenterByNameWithExperience()
        {
            var result = GetAll().SelectMany(x => x.Employees).Where(z => z.Experience > 5);

            return result;
        }


    }
}
