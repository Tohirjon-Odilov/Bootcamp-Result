namespace _11_lesson_List_LinkedList_SortedList_HashTable
{
    /// <summary>
    /// 707. Design Linked List
    /// </summary>
    public class CustomStack
    {
        private int maxSize;

        private List<int> myList = new List<int>();

        public CustomStack(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public void Push(int x)
        {
            if (myList.Count + 1 > maxSize)
            {
                return;
            }
            myList.Add(x);
        }

        public int Pop()
        {
            bool isEmpty = !myList.Any();
            if (isEmpty)
            {
                return -1;
            }
            var last = myList.Last();
            myList.RemoveAt(myList.Count - 1);
            return last;


        }

        public void Increment(int k, int val)
        {
            var i = 0;
            foreach (int listData in myList.ToArray())
            {
                if (i < k)
                {
                    myList[i] = listData + val;
                }
                i++;
            }
        }
    }
}
