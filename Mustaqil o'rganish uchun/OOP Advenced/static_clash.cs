namespace OOP_Advenced
{
    public static class static_clash
    {

        // static class'da constructor bo'lmaydi.
        //public static_clash() {}
        public static void MyMessages()
        {
            Console.WriteLine("Bu static class");
        }

    }

    public class NormalClass
    {
        //static class'dan voris olib bo'lmaydi
        public static void MyClass()
        {
            GC.Collect();
            Console.WriteLine("Static method");
        }
    }
}
