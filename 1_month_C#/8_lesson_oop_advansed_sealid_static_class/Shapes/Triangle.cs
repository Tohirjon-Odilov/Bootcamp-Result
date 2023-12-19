namespace _8_lesson_oop_advansed_sealid_static_class.Shape
{
    public class Triangle : Shape
    {
        private double firstSide;
        private double secondSide;
        private double thirdSide;

        public Triangle(double firstSide, double secondSide, double thirdSide, double x, double y) : base(x, y)
        {
            this.firstSide = firstSide;
            this.secondSide = secondSide;
            this.thirdSide = thirdSide;
        }

        public override double CalculateArea()
        {
            var p = (firstSide + secondSide + thirdSide) / 2;
            return Math.Sqrt(p * (p - firstSide) * (p - secondSide) * (p - thirdSide));
        }

        public override double CalculatePerimeter()
        {
            return firstSide + secondSide + thirdSide;
        }
    }
}
