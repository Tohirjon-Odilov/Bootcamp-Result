namespace _9_lesson_OOP_polymorphizm
{
public class Struct
{
    public Struct()
    {
        Talaba talaba = new Talaba() { age = 1, name = "Tohirjon" };
        Talaba talaba1 = new Talaba() { age = 2, name = "Tohirjon1" };

    }
    public struct Talaba
    {
        public string name;
        public int age;
    }
}
}
