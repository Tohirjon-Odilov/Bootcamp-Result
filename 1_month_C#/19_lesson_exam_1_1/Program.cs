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

using System;

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