namespace _11_lesson_List_LinkedList_SortedList_HashTable
{
    /// <summary>
    /// 707. Design Linked List
    /// </summary>
    public class MyLinkedList
    {
        List<int> myList;

        public MyLinkedList()
        {
            myList = new();
        }

        public int Get(int index)
        {
            if (index < 0 || index >= myList.Count)
                return -1;

            return myList[index];
        }

        public void AddAtHead(int val)
        {
            myList.Insert(0, val);
        }

        public void AddAtTail(int val)
        {
            myList.Add(val);
        }

        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index > myList.Count)
                return;

            myList.Insert(index, val);
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= myList.Count)
                return;

            myList.RemoveAt(index);
        }
    }
}
