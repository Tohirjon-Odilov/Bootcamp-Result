namespace _11_lesson_List_LinkedList_SortedList_HashTable
{
    public class MyArray
    {
        private int[] myList;
        private int leftPointer;
        private int rightPointer;
        public MyArray()
        {
            myList = new int[10];
            leftPointer = 0;
            rightPointer = 0;
        }
        public void Add(int num) 
        {
            Array.Resize(ref myList, myList.Length + 1);
            myList[rightPointer++] = num;
        }
        public void RemoveFirst(int num) 
        {
            leftPointer++;
        }
        public void RemoveLast(int num) 
        {
            if(rightPointer > leftPointer)
            {
                rightPointer--;
            }
        }
        public void GetItems() 
        {
            for (int i = leftPointer; i < rightPointer; i++) 
            {
                Console.WriteLine(myList[i]);
            }
        }
    }
}
