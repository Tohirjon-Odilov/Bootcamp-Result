namespace _7_lesson_oop_davomi
{
    internal class Vehicle
    {
        public string? Engine { get; set; }
        public DateOnly CreateDate { get; set; }

        public Vehicle(string engine, DateOnly createDate)
        {
            Engine = engine;
            CreateDate = createDate;
        }

        public void StartEngine(string str)
        {
            Console.WriteLine(str);
        }
        public void StopEngine(string str)
        {
            Console.WriteLine(str);
        }
        public void Drive(string str)
        {

        }
    }
}
