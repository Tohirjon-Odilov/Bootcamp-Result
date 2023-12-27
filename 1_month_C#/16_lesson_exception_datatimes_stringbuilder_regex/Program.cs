using _16_lesson_exception_datatimes_stringbuilder_regex.Models.Students;

namespace _16_lesson_exception_datatimes_stringbuilder_regex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var student = new Student("John", 20);
                Console.WriteLine("Try block is working");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch block is working");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
