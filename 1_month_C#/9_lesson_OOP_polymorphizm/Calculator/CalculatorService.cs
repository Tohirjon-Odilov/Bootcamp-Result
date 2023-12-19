namespace _9_lesson_OOP_polymorphizm.Calculator
{
    public partial class CalculatorService
    {
        public CalculatorService(int a, int b)
        {
            this.a = a;
            this.b = b;

            Multiply(a,b);
            Divide(a,b);
            Divorse(a,b);
            Add(a,b);
        }

        public int a { get; set; }
        public int b { get; set; }
    }
}
