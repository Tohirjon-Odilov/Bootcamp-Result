using System.Numerics;

namespace _9_lesson_OOP_polymorphizm.Calculator
{
    public partial class CalculatorService<MyInt> : ICalculatorService<MyInt>
        where MyInt : INumber<MyInt>
    {
        public void Add(MyInt a, MyInt b) => Console.WriteLine(a + b);
        public void Divide(MyInt a, MyInt b) => Console.WriteLine(a / b);
        public void Divorse(MyInt a, MyInt b) => Console.WriteLine(a - b);
        public void Multiply(MyInt a, MyInt b) => Console.WriteLine(a * b);
    }
}
