

//for  (int i = 0; i < arr.GetLength(0); i++)
//{
//    for (int j = 0; j < arr.GetLength(1); j++)
//    {
//        if (arr[i, j] == 4)
//        {
//            Console.WriteLine(arr[i,j]);
//        }
//    }
//}
//*/

//int[][] myJaggedArray = new int[4][];

//myJaggedArray[0] = new int[] { 1, 2, 6 };
//myJaggedArray[1] = new int[] { 1, 2, 6, 56, 3, 1 };
//myJaggedArray[2] = new int[] { 1, 1 };
//myJaggedArray[3] = new int[] { 1, 1, 34, 434, 34, 3, 4, 34, 3, 43, 43 };

//Console.WriteLine(myJaggedArray[1][3]);
//Console.WriteLine(myJaggedArray[3][4]);

//int[] arr = [1, 2, 1];


//using _6_Lesson_kopolchamli_array;

//var person = new Dog();
//person.Bit();






///*int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 } };
internal class Program
{
    public static bool isWin = false;
    public static string[,] arr = {
        //{" 5"," 4","12","10" },
        //{" 7"," 9","11"," 8" },
        //{"  "," 2","15","13"},
        //{" 6","14"," 3"," 1" }
        {" 1"," 2"," 3"," 4"},
        {" 5"," 6"," 7"," 8"},
        {" 9","10","11","12"},
        {"13","14","  ","15"}
    };

    public static string[,] arrTrue = {
        {" 1"," 2"," 3"," 4"},
        {" 5"," 6"," 7"," 8"},
        {" 9","10","11","12"},
        {"13","14","15","  "}
    };
    private static void Main(string[] args)
    {
        while (true)
        {
            isWin = AreArraysEqual(arr, arrTrue);
            if (!isWin)
            {
                if (isWin)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    toShow();
                    Console.ResetColor();
                    return;
                }
                toShow();

                var key = Console.ReadKey();

                Console.Clear();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    toBottom();
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    toTop();
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    toRight();
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    toLeft();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return;
                }
                Console.Clear();
            }
        }
    }


    #region bottom
    public static void toBottom()
    {
        for (var i = 0; i < arr.GetLength(0); i++)
        {
            for (var j = 0; j < arr.GetLength(1); j++)
            {
                if (i - 1 > -1 && arr[i, j] == "  ")
                {
                    arr[i, j] = arr[i - 1, j];
                    arr[i - 1, j] = "  ";
                }
            }
        }
    }
    #endregion

    #region right
    public static void toRight()
    {
        for (var i = 0; i < arr.GetLength(0); i++)
        {
            for (var j = 0; j < arr.GetLength(1); j++)
            {
                if (j - 1 > -1 && arr[i, j] == "  ")
                {
                    arr[i, j] = arr[i, j - 1];
                    arr[i, j - 1] = "  ";
                }
            }
        }
    }
    #endregion

    #region top
    public static void toTop()
    {
        for (var i = 0; i < arr.GetLength(0); i++)
        {
            for (var j = 0; j < arr.GetLength(1); j++)
            {
                if (i + 1 < 4 && arr[i, j] == "  ")
                {
                    arr[i, j] = arr[i + 1, j];
                    arr[i + 1, j] = "  ";
                    return;
                }
            }
        }
    }
    #endregion

    #region left
    public static void toLeft()
    {
        for (var i = 0; i < arr.GetLength(0); i++)
        {
            for (var j = 0; j < arr.GetLength(1); j++)
            {
                if (j + 1 < 4 && arr[i, j] == "  ")
                {
                    arr[i, j] = arr[i, j + 1];
                    arr[i, j + 1] = "  ";
                    return;
                }
            }
        }
    }
    #endregion

    #region check
    public static bool AreArraysEqual(string[,] arr1, string[,] arr2)
    {
        if (arr1.GetLength(0) != arr2.GetLength(0) || arr1.GetLength(1) != arr2.GetLength(1))
        {
            return false;
        }

        for (int i = 0; i < arr1.GetLength(0); i++)
        {
            for (int j = 0; j < arr1.GetLength(1); j++)
            {
                if (arr1[i, j] != arr2[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }
    #endregion

    #region toShow
    public static void toShow()
    {
        for (int i = 0; i < arr.GetLength(0); i++) {
            for (int j = 0;j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
        
    #endregion
}