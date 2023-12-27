namespace _16_lesson_exception_datatimes_stringbuilder_regex.Models.Students.Exceptions
{
    public class InvalidStudentNameException : Exception
    {
        // parameter class constructor
        public InvalidStudentNameException()
        : base()
        {}

        // message parametrli constructor
        public InvalidStudentNameException(string message)
        : base(message)
        {}
    }
}
