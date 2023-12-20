namespace _9_lesson_OOP_polymorphizm.Medical
{
    public partial class Run
    {
        public bool isRun = true;
        public string? userSelect;
        public void RunUi()
        {

            while (isRun)
            {
                Console.WriteLine("<<1>> Bemor qo'shish.");
                Console.WriteLine("<<2>> Bemor haqida ma'lumot olish.");
                Console.WriteLine("<<3>> Doctor qo'shish.");
                Console.WriteLine("<<4>> Doctor haqida ma'lumot olish.");
                Console.WriteLine("<<5>> Shifokorga be'mor biriktirish.");
                Console.WriteLine("<<0>> Dasturni to'xtatish.");
                userSelect = Console.ReadKey().ToString();
            }
        }
    }
}
