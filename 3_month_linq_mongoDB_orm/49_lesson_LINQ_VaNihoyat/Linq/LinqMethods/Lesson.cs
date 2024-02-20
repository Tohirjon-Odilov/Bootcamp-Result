using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.LinqMethods
{
    internal class Lesson
    {
        public Lesson()
        {
            var numbers = new List<int>() { 1, 3, 4, 5, 6};
            var evenNumQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            int evenNumCount = evenNumQuery.Count();

            foreach (var num in evenNumQuery)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine(evenNumCount);


        }
    }
}
