//namespace _14_lesson_Func_Action_Predicate_Lyambda_Anonym_function.Amaliyot
//{
//    public class Sarvar_aka
//    {
//        public static Func<int, int> myChanger = default!;

//        public static int ChangeArrayElements(int[] array, Func<int, int> changer)
//        {
//            for (int i = 0; i < array.Length; i++)
//            {
//                array[i] = changer(array[i]);
//            }

//            return 0;
//        }
//        static void Main(string[] args)
//        {
//            int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9];

//            myChanger = x => x * 2;

//            ChangeArrayElements(array, changer: myChanger);

//            foreach (int el in array)
//            {
//                Console.WriteLine(el);
//            }
//            Console.WriteLine(ChangeArrayElements);

//            ChangeArrayElements(array, changer: Triple);

//            foreach (int el in array)
//            {
//                Console.WriteLine(el);
//            }
//        }

//        static int Triple(int x)
//        {
//            return x * 3;
//        }
//    }
//}
