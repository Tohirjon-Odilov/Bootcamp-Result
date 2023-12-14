namespace _7_lesson_oop_davomi
{
    internal class Airplane : Vehicle
    {
        public Airplane(string engine, DateOnly createDate, string wings) : base(engine, createDate)
        {
            Engine = engine;
            CreateDate = createDate;
            Wings = wings;
        }
        public string Wings { get; set; }
        public void Land(string str)
        {
            Console.WriteLine(str);
        }
        public void TakeOff(string str)
        {
            Console.WriteLine(str);
        }
    }
}
