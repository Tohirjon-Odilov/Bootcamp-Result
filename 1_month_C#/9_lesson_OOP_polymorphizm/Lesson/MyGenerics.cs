namespace _9_lesson_OOP_polymorphizm
{
    internal class MyGenerics <MyString, MyInt>
    {
        public MyString? name;
        public MyInt? year;
        public MyInt? month;
        public MyInt? day;
        public MyGenerics()
        {
            Console.WriteLine($"Maning ismim {name}. Men {year} - yil {month} - oy {day} da tug'ilganman. ");
        }
    }
}
