#region lesson txt
// polymorthizm (
// overloading, overriding) 
// interace => interfeys faqat interfeysdan vorish oladi. bir nechta interface'ni ichida bir-xil method ochilsa voris olingan classda har bir inreface'ni methodini ishlatish uchun anashu interfaceni nomini yozib method chaqirialdi lekin u methdi boshqa classlarda ishlata olmaymiz olingan objectdayam
// 
// partial
// enum
// struct
#endregion

public interface IMyClass
{
    public static void MyMessage()
    {
        Console.WriteLine("Hello interface");
    }
}

// STRUCT
public struct MyStruct
{
    public int test;
    public int test1;
}

//IMyClass.Equals();
//var hi = new IMyClass();