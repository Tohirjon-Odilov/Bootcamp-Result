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
myLinkedList.AddAtIndex(1, 2);
Console.WriteLine(myLinkedList.Get(1));
myLinkedList.DeleteAtIndex(1);
Console.WriteLine(myLinkedList.Get(1));

CustomStack stk = new CustomStack(3);
stk.Push(1);
stk.Push(2);
Console.WriteLine(stk.Pop());
stk.Push(2);
stk.Push(3);
stk.Push(4);
stk.Increment(5, 100);
stk.Increment(2, 100);
Console.WriteLine(stk.Pop());
Console.WriteLine(stk.Pop());
Console.WriteLine(stk.Pop());
Console.WriteLine(stk.Pop());
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

