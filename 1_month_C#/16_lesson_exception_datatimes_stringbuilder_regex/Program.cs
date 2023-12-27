using _16_lesson_exception_datatimes_stringbuilder_regex.Models.Students;
using _16_lesson_exception_datatimes_stringbuilder_regex.Models.Students.Exceptions;

namespace _16_lesson_exception_datatimes_stringbuilder_regex
{
    internal class Program
    {
        public static Student? InitStudent(string name, int age)
        {
            try
            {
                var student = new Student(name, age);
                Console.WriteLine("Try block is working");
                return student;
            }
            catch (InvalidStudentNameException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Let's input your name again");
                //Console.WriteLine();
                string anotherAttempt = Console.ReadLine()!;
                return InitStudent(anotherAttempt, age);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch block is working");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
                return null;
            }
        }
        static void Main(string[] args)
        {
            var student = InitStudent("John", 20);   
        }
    }
}
