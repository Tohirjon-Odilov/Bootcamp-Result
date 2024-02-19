using static System.Formats.Asn1.AsnWriter;
using System.Linq;
using LINQLess.LinqMethods;

namespace LINQLess
{
    internal class Program
    {
        static void Main(string[] args)
        {

            LINQForEduCenter data = new LINQForEduCenter();
            //foreach (var item in data.GetCenterByName("Najot Ta'lim"))
            //{
            //    var empoyees = item.Employees.Select(x => x).Where(z => z.Experience > 5);
            //    Console.WriteLine(item.Name);
            //    foreach(var employee in empoyees)
            //    {
            //        Console.WriteLine(employee.FirstName + " " + employee.LastName);
            //    }
            //}

            foreach (var item in data.GetCenterByNameWithExperience())
            {
                Console.WriteLine(item.FirstName + " " + item.Experience);
            }


        }
    }
}
