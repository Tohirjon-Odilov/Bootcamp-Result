﻿namespace _14_lesson_Func_Action_Predicate_Lyambda_Anonym_function.Homework
{
    public class BubbleSearch
    {
        public static void SortArray(int[] array, Func<int[], int[]> func)
        {
            array = func(array);
        }

        static void Main(string[] args)
        {

            int[] array = [5, 6, 1, 2, 3, 10];

            SortArray(array, func: AscendingSort);
            Console.WriteLine("O'sish tartibda tartiblangan.");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            SortArray(array, func: DescendingSort);
            Console.WriteLine("Kamayish tartibda tartiblangan.");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            SortArray(array, func: AlphabeticalSort);
            Console.WriteLine("Alphabetic tartibda tartiblangan.");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

        }
        public static int[] AscendingSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int box = array[i];
                        array[i] = array[j];
                        array[j] = box;
                    }
                }
            }
            return array;
        }

        public static int[] DescendingSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        int box = array[i];
                        array[i] = array[j];
                        array[j] = box;
                    }
                }
            }
            return array;
        }

        public static int[] AlphabeticalSort(int[] array)
        {
            string[] newArray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i].ToString();
            }
            Array.Sort(newArray);

            for (int j = 0; j < array.Length; j++)
            {
                array[j] = Convert.ToInt32(newArray[j]);
            }
            return array;
        }

    }

}
