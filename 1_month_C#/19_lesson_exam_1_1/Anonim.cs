namespace _19_lesson_exam_1_1
{
    public class Anonim
    {
        public Anonim()
        {
            Console.Clear();
            Console.WriteLine("Salom");

            Func<int, int, int> myAnonim = delegate (int a, int b)
            {
                return a + b;
            };

            Func<int, int, int> myLambda = (int a, int b) =>
            {
                return a + b;
            };
            object test = "salom";
            //Console.WriteLine(test.toUpper(0));

            //ValueTuple
            Console.WriteLine(myAnonim(2, 3));
        }
    }
}