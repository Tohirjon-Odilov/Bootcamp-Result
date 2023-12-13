/*int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 } };

for  (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        if (arr[i, j] == 4)
        {
            Console.WriteLine(arr[i,j]);
        }
    }
}
*/

int[][] myJaggedArray = new int[4][];

myJaggedArray[0] = new int[] { 1, 2, 6 };
myJaggedArray[1] = new int[] { 1, 2, 6, 56, 3, 1 };
myJaggedArray[2] = new int[] { 1, 1 };
myJaggedArray[3] = new int[] { 1, 1, 34, 434, 34, 3, 4, 34, 3, 43, 43 };

Console.WriteLine(myJaggedArray[1][3]);
Console.WriteLine(myJaggedArray[3][4]);
