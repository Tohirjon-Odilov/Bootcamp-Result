namespace _9_lesson_OOP_polymorphizm
{
    internal class MyGenerics<MyString, MyInt>
    {
        public MyString? name;
        public MyInt? year;
        public MyInt? month;
        public MyInt? day;

        public MyGenerics(MyString name, MyInt year, MyInt month, MyInt day)
        {
            this.name = name;
            this.year = year;
            this.month = month;
            this.day = day;
        }
        public string About() => $"Mening ismim {name}. {year}/{month}/{day} kun tavallud topganman. \nbu enum=>" +
            $"{(int)MyEnum.affirmative}";
    }
}
