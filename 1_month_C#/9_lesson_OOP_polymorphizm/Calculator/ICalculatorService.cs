namespace _9_lesson_OOP_polymorphizm.Calculator
{
    public interface ICalculatorService<MyInt>
    {
        public void Multiply(MyInt a, MyInt b);
        public void Divide(MyInt a, MyInt b);
        public void Add(MyInt a, MyInt b);
        public void Divorse(MyInt a, MyInt b);
    }
}
