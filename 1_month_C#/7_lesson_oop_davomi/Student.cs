namespace _7_lesson_oop_davomi
{
    internal class Student : Person
    {
        public string[] Lessons;
        private bool isScholorShip = false;
        public string Name;
        public Student(string name, DateOnly dateofbirth, bool isScholorShip) : base(name, dateofbirth) { 
            Name = name;
            Lessons = ["matematika", "ingiliz-tili", "Ona-Tili"];
        }
        public void Learn()
        {
            Console.WriteLine($"{Name} is learning {Lessons[1]}.");
        }
    }
}
