namespace _7_lesson_oop_davomi
{
    internal class Car : Vehicle
    {
        public Car(string engine, DateOnly createDate, string wheel) : base(engine, createDate)
        {
            Engine = engine;
            CreateDate = createDate;
            Wheel = wheel;
        }
        public string Wheel { get; set; }
        public void Accelerate(string str)
        {
            Console.WriteLine(str);
        }
        public void Brake(string str)
        {
            Console.WriteLine(str);
        }
    }
}
