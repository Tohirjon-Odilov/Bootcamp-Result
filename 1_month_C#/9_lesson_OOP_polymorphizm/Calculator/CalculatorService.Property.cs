namespace _9_lesson_OOP_polymorphizm.Calculator
{
    public partial class CalculatorService : ICalculatorService
    {
        public void Add(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        public void Divide(int a, int b)
        {
            Console.WriteLine(a / b);
        }

        public void Divorse(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        public void Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }
    }
}
