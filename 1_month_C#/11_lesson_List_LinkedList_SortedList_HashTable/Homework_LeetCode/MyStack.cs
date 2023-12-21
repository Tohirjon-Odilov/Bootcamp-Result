namespace _11_lesson_List_LinkedList_SortedList_HashTable
{
    /// <summary>
    /// 225. Implement Stack using Queues
    /// </summary>
    public class MyStack
    {
        private Queue<int> queue;

        public MyStack()
        {
            queue = new Queue<int>();
        }

        public void Push(int x)
        {
            queue.Enqueue(x);
            int length = queue.Count;
            while (length > 1)
            {
                queue.Enqueue(queue.Dequeue());
                length--;
            }
        }

        public int Pop()
        {
            if (queue.Count == 0)
            {
                return -1;
            }
            return queue.Dequeue();
        }

        public int Top()
        {
            if (queue.Count == 0)
            {
                return -1;
            }
            return queue.Peek();
        }

        public bool Empty()
        {
            return queue.Count == 0;
        }
    }
}
