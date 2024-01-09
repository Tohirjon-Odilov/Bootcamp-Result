namespace _20_lesson_exam_1_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Service teacher = new Service();

            Teacher person = new Teacher()
            {
                Id = 4,
                FirstName = "Aziz",
                SecondName = "Shokirov",
                Subject = "Bootcamp Foundation"
            };
            teacher.AddData(person);
        }
    }
}