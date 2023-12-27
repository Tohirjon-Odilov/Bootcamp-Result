using _16_lesson_exception_datatimes_stringbuilder_regex.Homework;
using _16_lesson_exception_datatimes_stringbuilder_regex.Models.Students;
using _16_lesson_exception_datatimes_stringbuilder_regex.Models.Students.Exceptions;
using System.Text.RegularExpressions;

namespace _16_lesson_exception_datatimes_stringbuilder_regex
{
    public class Program
    {
        #region Task Main
        /*
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
        }*/
        #endregion
        static void Main(string[] args)
        {
            #region Task object
            //var student = InitStudent("John", 20);
            #endregion

            #region Homework task 3 Validation
            //while (true)
            //{
            //    Console.Clear();
            //    Console.Write("<<1>> Check email.\n"
            //    + "<<2>> Check phone number.\n"
            //    + "<<3>> Check password.\n"
            //    + "<<4>> Check birthday.\n"
            //    + "<<0>> Exit. \n>> ");
            //    string userSelection = Console.ReadLine()!;
            //    var validation = new Task3_Registration(userSelection);
            //}
            #endregion
            #region Task 4
            Task4 task4 = new Task4();
            #endregion
        }
    }
}
