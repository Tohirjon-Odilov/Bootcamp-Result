//namespace d;

//void sum(int c, out int a, out int b)
//{
//    b = 2+5;
//    a = 2+6;
//}
//int c = 2;
//sum(c, out int a, out int b);

//Console.WriteLine(a+" "+b);

//float a = 5;
//kvadrad(a, out float yuza1, out float peremetr1, out float radius1);

//Console.WriteLine(yuza1 + "  " + peremetr1 + " " + radius1);
//Console.ReadKey();
//static void kvadrad(float a, out float yuza, out float peremetr, out float radius)
//{
//    yuza = a * a;
//    peremetr = 4 * a;
//    radius = a / 2;
//}

/*
namespace Struktura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //talaba strukturasidan o'zgaruvchi yasash
            Talaba talaba1 = new Talaba();

            //ochiq xususiyatlarga qiymat berish
            talaba1.ism = "Dave";
            talaba1.familiya = "Thompson";

            //foydalanuvchining taxminiy yoshini kiritish
            int yosh = 17;

            //olingan qiymatni Eventga yuborish
            talaba1.PutAge(yosh);

            //private xususiyani Event orqali Consolega chiqarish
            talaba1.GetAge();

            Console.WriteLine(BigInteger.Max);

        }
    }

    //Struktura
    struct Talaba
    {
        //ochiq xususiyatlar-public properties
        public string ism;
        public string familiya;

        //yashirin xususiyatlar-private properties
        private int yosh;

        //yashirin xususiyatni(yosh) ko'rsatuvchi Event
        public void GetAge()
        {
            Console.WriteLine(yosh);
        }

        //Yashirin xususiyatga(yosh) qiymat beruvchi Event
        public void PutAge(int age)
        {
            yosh = age;
        }
    }
}
*/

//Predicate<int> result = x =>{return x % 2 == 0;};
////Console.WriteLine(result);
//Predicate<int> result1 = delegate (int x)
//{
//    return false;
//};
//bool Triangle (Tuple<int, int, int> value)
//{
//    return value.Item1 == value.Item2;
//}
//Predicate<Tuple<int, int, int>> isTriangle = Triangle;

//Console.WriteLine(isTriangle(new Tuple<int, int, int>(2,3,4)));

//int a = 20;
//int b = a >> 10; //Console.WriteLine(b);

//var stringBuilder = new StringBuilder("Welcome to stringBuilder => "); //var test = stringBuilder.AppendFormat("{0:C}", 157); //Console.WriteLine(test); Console.WriteLine(BigInteger.Max);

// int[1] myArray = {1, 2, 3};
// int myArray = new int[3] {1, 2, 3};
// int[] myArray = {1, 2, 3};
// // int myArray = {1, 2, 3};
//
// string s = "Computer";
// for(int i = 0; s.Length > i; i++)
// {
//     Console.WriteLine(s[i]);
// }
//


//delegat test = new delegat();
// MyFunc myFunc = new MyFunc();
//Anonim myAnonim = new Anonim();
//Out Out = new Out();
//Ref Ref = new Ref();

//ValueTuple<>
using _19_lesson_exam_1_1;

public class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine(4 + 5);
    }

    public static Out operator + (Out a, Out b) { return a - b; }
}
//public int operator +(int a, int b) { return a + b; }
//public static void operator +(int a, int b) { return a + b; }
//public static operator +(int a, int b) => a + b;