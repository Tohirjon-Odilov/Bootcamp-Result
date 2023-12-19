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

        public static class StaticClass { } // nested static class ocha olamiz

    }

    public sealed class SealedClass : NormalClass
    {
        /// <summary>
        /// Sealed class ichida nested class ocha olamiz
        /// Sealed class'da boshqa class'da vorish olib ishlatsa bo'ladi
        /// Ammo voris bermaydi
        /// Constructor'ga
        /// 
        /// </summary>
        public sealed class SealedClass2 // nested sealed class ocha olamiz
        {
            public SealedClass2()
            {
                Console.WriteLine("Hello sealed class");
            }
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
