// Program.cs'da ishga tushadi

namespace _9_lesson_OOP_polymorphizm.Calculator
{
    public partial class CalculatorService<MyInt>
    {
        public CalculatorService(MyInt a, MyInt b)
        {
            this.a = a;
            this.b = b;

            Multiply(a, b);
            Divide(a, b);
            Divorse(a, b);
            Add(a, b);
        }

        public MyInt a { get; set; }
        public MyInt b { get; set; }
    }
}
