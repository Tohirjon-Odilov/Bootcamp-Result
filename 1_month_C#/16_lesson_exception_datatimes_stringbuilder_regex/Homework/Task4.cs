using System.Text.RegularExpressions;

namespace _16_lesson_exception_datatimes_stringbuilder_regex.Homework
{
    internal class Task4
    {
        public Task4()
        {
            string matn = "w3resoSur_ce.com";
            string yangilanganQator = Regex.Replace(matn, @"[^A-z0-9_]", "");
            Console.WriteLine(yangilanganQator);
        }
    }
}
