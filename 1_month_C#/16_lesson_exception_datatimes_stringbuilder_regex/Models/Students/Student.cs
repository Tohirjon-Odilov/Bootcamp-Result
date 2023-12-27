using _16_lesson_exception_datatimes_stringbuilder_regex.Models.Students.Exceptions;

namespace _16_lesson_exception_datatimes_stringbuilder_regex.Models.Students
{
    public class Student
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public Student(string name, int age)
        {
            // Validation logic
            if (name.Length < 5)
            {
                throw new InvalidStudentNameException(
                    message: "Student name's length must be at least 5.");
            }

            if (age < 18)
            {
                throw new InvalidStudentAgeException(
                    message: "You are too young for that.");
            }
            Name = name;
            Age = age;
        }
    }
}
