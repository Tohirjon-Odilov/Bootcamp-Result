﻿//namespace _14_lesson_Func_Action_Predicate_Lyambda_Anonym_function.Lesson
//{
//    public class Rectangle
//    {
//        //public bool ISRectangle = false;
//        public Rectangle(params int[] tomonlar)
//        {
//            IsRectangle(tomonlar);
//            //if (ISRectangle)
//            //{
                
//            //}
//            //else
//            //{
//            //    Console.WriteLine("To'g'ri to'rtburchakmasligi uchun ishlamaydi");
//            //}
//        }
//        public void IsRectangle(params int[] tomonlar)
//        {
//            if (tomonlar.Length == 2)
//            {
//                //ISRectangle = true;
//                Console.WriteLine("To'g'ri to'rtburchak");
//            }
//            else if (tomonlar.Length == 4)
//            {
//                Console.WriteLine("To'rtburchak");
//            }
//            else
//            {
//                Console.WriteLine("To'rtburchak emas");
//            }
//        }
//        Predicate<Tuple<int[], int>> ISRectangle = delegate (Tuple<int[], int> tomonlar)
//        {
//            Console.WriteLine(tomonlar);
//            //if (tomonlar.Length == 2)
//            //{
//            //    //ISRectangle = true;
//            //    Console.WriteLine("To'g'ri to'rtburchak");
//            //}
//            //else if (tomonlar.Length == 4)
//            //{
//            //    Console.WriteLine("To'rtburchak");
//            //}
//            //else
//            //{
//            //    Console.WriteLine("To'rtburchak emas");
//            //}
//            return true;
//        };

//        public void Perimetr(params int[] tomonlar)
//        {
//            int sum = 0;
//            foreach (int i in tomonlar)
//            {
//                sum += i;
//            }
//            Console.WriteLine(sum);
//        }
//        public void Yuzi(params int[] tomonlar)
//        {
//            Console.WriteLine(tomonlar[0] * tomonlar[1]);
//        }
//        public void Diagonal(params int[] tomonlar)
//        {
//            Console.WriteLine(Math.Sqrt((Math.Pow(tomonlar[0], 2)) + Math.Pow(tomonlar[1], 2)));
//        }
//    }
//}
