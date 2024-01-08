namespace _19_lesson_exam_1_1
{
    public class Ref
    {
        static void Main(string[] args)
        {
            int a = 8, b = 5;

            swapp(ref a, ref b);

            Console.WriteLine(a + "  " + b);
            Console.ReadKey();
        }
        static void swapp(ref int a, ref int b)
        {
            int k = a;
            a = b;
            b = k;
        }
    }
}