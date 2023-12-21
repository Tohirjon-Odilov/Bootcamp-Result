using _11_lesson_List_LinkedList_SortedList_HashTable;
#region homework
MyQueue task1 = new MyQueue();
task1.Push(4);
task1.Push(5);
task1.Push(6);
task1.Push(19);
Console.WriteLine(task1.Peek());
Console.WriteLine(task1.Pop());
Console.WriteLine(task1.Empty());

MyStack task2 = new MyStack();
task2.Push(1);
task2.Push(2);
task2.Push(3);
Console.WriteLine(task2.Top());
Console.WriteLine(task2.Pop());
Console.WriteLine(task2.Empty());

MyLinkedList myLinkedList = new MyLinkedList();
myLinkedList.AddAtHead(1);
myLinkedList.AddAtTail(3);
myLinkedList.AddAtIndex(1, 2);    // linked list becomes 1->2->3
Console.WriteLine(myLinkedList.Get(1));              // return 2
myLinkedList.DeleteAtIndex(1);    // now the linked list is 1->3
Console.WriteLine(myLinkedList.Get(1));              // return 3

CustomStack stk = new CustomStack(3); // Stack is Empty []
stk.Push(1);                          // stack becomes [1]
stk.Push(2);                          // stack becomes [1, 2]
Console.WriteLine(stk.Pop());                            // return 2 --> Return top of the stack 2, stack becomes [1]
stk.Push(2);                          // stack becomes [1, 2]
stk.Push(3);                          // stack becomes [1, 2, 3]
stk.Push(4);                          // stack still [1, 2, 3], Do not add another elements as size is 4
stk.Increment(5, 100);                // stack becomes [101, 102, 103]
stk.Increment(2, 100);                // stack becomes [201, 202, 103]
Console.WriteLine(stk.Pop());                            // return 103 --> Return top of the stack 103, stack becomes [201, 202]
Console.WriteLine(stk.Pop());                            // return 202 --> Return top of the stack 202, stack becomes [201]
Console.WriteLine(stk.Pop());                            // return 201 --> Return top of the stack 201, stack becomes []
Console.WriteLine(stk.Pop());                            // return -1 --> Stack is empty return -1.
#endregion

#region text
//List, LinkedList, SortedList, stack, queue, hashtable, hashset, Dictinory

//HashSet<string> names = new HashSet<string>();
//IDictionary<string, string> dic = new Dictionary<string, string>()
//{
//    { "key1", "value1" }
//};
#endregion

#region Lesson

//MyArray myArray = new MyArray();
//myArray.Add(1);
//myArray.Add(2);
//myArray.Add(3);
//myArray.GetItems();
//myArray.RemoveFirst(2);
//myArray.GetItems();


#endregion

