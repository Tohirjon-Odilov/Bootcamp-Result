namespace _11_lesson_List_LinkedList_SortedList_HashTable
{
    /// <summary>
    /// 232. Implement Queue using Stacks
    /// </summary>
    public class MyQueue
    {
        private Stack<int> stack1;
        private Stack<int> stack2;

        public MyQueue()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        public void Push(int x)
        {
            stack1.Push(x);
        }

        public int Pop()
        {
            if (Empty())
            {
                return Int32.MinValue;
            }
            while (stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
            int value = stack2.Pop();
            while (stack2.Count > 0)
            {
                stack1.Push(stack2.Pop());
            }
            return value;
        }

        public int Peek()
        {
            if (Empty())
            {
                return Int32.MinValue;
            }
            while (stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
            int value = stack2.Peek();
            while (stack2.Count > 0)
            { 
                stack1.Push(stack2.Pop());
            }
            return value;
        }

        public bool Empty()
        {
            return stack1.Count == 0;
        }
    }
}
