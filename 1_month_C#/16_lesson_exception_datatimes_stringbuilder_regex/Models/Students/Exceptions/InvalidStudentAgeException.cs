namespace _16_lesson_exception_datatimes_stringbuilder_regex.Models.Students.Exceptions
{
    internal class InvalidStudentAgeException : Exception
    {
        public InvalidStudentAgeException(string message) : base(message)
        {
            
        }
    }
}
