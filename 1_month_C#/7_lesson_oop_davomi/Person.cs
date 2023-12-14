namespace _7_lesson_oop_davomi
{
    internal class Person
    {
        public string Name;
        public DateOnly DateOfBirth;
        public Person() {
            Console.WriteLine("Men bu men!");
            Name = "Unknown";
        }
        public Person(string Name, DateOnly DateOfBirth) {
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
        }
        public void Breath()
        {
            Console.WriteLine($"{ Name } is breathing!");
        }
    }
}
