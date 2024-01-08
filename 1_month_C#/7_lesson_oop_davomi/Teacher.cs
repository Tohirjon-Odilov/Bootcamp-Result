namespace _7_lesson_oop_davomi
{
    internal class Teacher : Person
    {
        public string[] Lessons;
        private decimal Salary;
        public Teacher(string Name, DateOnly DateOfBirth, decimal Salary) : base(Name, DateOfBirth)
        {
            Lessons = ["matematika", "ingiliz-tili", "Ona-Tili"];
        }
        public void Teach()
        {
            Console.WriteLine($"{Lessons[0]} shu fandan dars o'tmoqda");
        }
    }
}
