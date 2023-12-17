namespace _8_lesson_oop_advansed_sealid_static_class
{
    public abstract class Shape : Point
    {
        public Point CenterPoint;
        public Shape(double x, double y) : base (x, y)
        {
            CenterPoint = new Point (x, y);
        }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
}
