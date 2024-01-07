namespace _19_lesson_exam_1_1
{
    public class MyFunc
    {
        public MyFunc()
        {
            Console.Clear();
            Func<int, int, string> myFuncAdd = Add;
            Console.WriteLine(myFuncAdd(2,9));
        }

        // oldin e'lon qilib olsa ham bo'ladi.
        //public delegate TResult Func<in T1, in T2, out TResult>(T1 arg, T2 arg2);

        private static string Add(int arg1, int arg2)
        {
            return Convert.ToString(arg1 + arg2) + " Chiqdimi";
        }
    }
}