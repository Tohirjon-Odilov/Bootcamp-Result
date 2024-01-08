namespace _19_lesson_exam_1_1
{
    public class Out
    {
        public readonly Ref obj;

        public Out(Ref obj)
        {
            this.obj = obj;
        }

        public Out()
        {
            float a = 5;
            kvadrad(a, out float yuza1, out float peremetr1, out float radius1);

            Console.WriteLine(yuza1 + "  " + peremetr1 + " " + radius1);
        }
        public void kvadrad(float a, out float yuza, out float peremetr, out float radius)
        {
            yuza = a * a;
            peremetr = 4 * a;
            radius = a / 2;
        }
    }
}
