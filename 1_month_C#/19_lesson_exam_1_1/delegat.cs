namespace _19_lesson_exam_1_1
{
    public class delegat
    {
        public delegat()
        {
            PrintNum pt1 = new PrintNum(qosh);
            PrintNum pt2 = new PrintNum(ayir);
            
            // multicase delegat'ga misol
            PrintNum multicase = pt1 + pt2;
            
            // multicase delegat'ni bittasini o'chirish 
            multicase -= pt1;

            multicase(2,3);

            // qiymat berishni yana bir usuli
            // multicase.Invoke(510,5);

        }
        
        public delegate void PrintNum(int a, int b);
        
        public void qosh(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        public void ayir(int a, int b)
        {
            Console.WriteLine($"{a}{b}");
        }
    }
    /*
     * using System;
     * delegate'dan foydalanmasdan qilingan /////////////////////////////////////////////

delegate int NumberChanger(int n);
namespace DelegateAppl {
   class TestDelegate {
      static int num = 10;
      
      public static int AddNum(int p) {
         num += p;
         return num;
      }
      public static int MultNum(int q) {
         num *= q;
         return num;
      }
      public static int getNum() {
         return num;
      }
      static void Main(string[] args) {
         //create delegate instances
         NumberChanger nc;
         NumberChanger nc1 = new NumberChanger(AddNum);
         NumberChanger nc2 = new NumberChanger(MultNum);
         
         nc = nc1;
         nc += nc2;
         
         //calling multicast
         nc(5);
         Console.WriteLine("Value of Num: {0}", getNum());
         Console.ReadKey();
      }
   }
}
     */
}