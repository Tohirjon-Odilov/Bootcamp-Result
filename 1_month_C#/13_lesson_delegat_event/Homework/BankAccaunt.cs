using Bank;

public class BankAccount
{
    public delegate double Account(double sum, int years);
    public static void Main(string[] args)
    {
        Kredit Kredit = new Kredit();
        while (true)
        {
            #region Tanlov qismi
            Console.Clear();
            Console.Write("Kredit tanlang: \n" +
                "<<1>> Ipoteka kredit\n" +
                "<<2>> Mahina kredit\n" +
                "<<3>> Maqsadsiz kredit\n" +
                "<<4>> Imtiyozli kredit\n" +
                "<<5>> Ta'lim kredit\n" +
                "<<6>> Dasturni tugatish.\n" +
                ">> ");
            string UserChoice = Console.ReadLine()!;
            #endregion
            #region Ipoteka kredit
            if (UserChoice == "1")
            {
                Console.Clear();
                Console.Write("Miqdor kiriting>> ");

                double sum = double.Parse(Console.ReadLine()!);
                Console.Write("Necha yilga olmoqchisiz>> ");

                int year = int.Parse(Console.ReadLine()!);
                Account account1 = Kredit.Ipoteka;

                Console.WriteLine(account1(sum, year));
                Console.ReadKey();
            }
            #endregion
            #region Mashina kredit
            else if (UserChoice == "2")
            {
                Console.Clear();
                Console.Write("Miqdor kiriting>> ");

                double sum = double.Parse(Console.ReadLine()!);
                Console.Write("Necha yilga olmoqchisiz>> ");

                int year = int.Parse(Console.ReadLine()!);
                Account account2 = Kredit.Mashina;

                Console.WriteLine(account2(sum, year));
                Console.ReadKey();
            }
            #endregion
            #region Maqsadsiz kredit
            else if (UserChoice == "3")
            {
                Console.Clear();
                Console.Write("Miqdor kiriting>> ");

                double sum = double.Parse(Console.ReadLine()!);
                Console.Write("Necha yilga olmoqchisiz>> ");

                int year = int.Parse(Console.ReadLine()!);
                Account account3 = Kredit.Maqsadsiz;

                Console.WriteLine(account3(sum, year));
                Console.ReadKey();
            }
            #endregion
            #region Imtiyozli kredit
            else if (UserChoice == "4")
            {
                Console.Clear();
                Console.Write("Miqdor kiriting>> ");

                double sum = double.Parse(Console.ReadLine()!);
                Console.Write("Necha yilga olmoqchisiz>> ");

                int year = int.Parse(Console.ReadLine()!);
                Account account4 = Kredit.Imtiyozli;

                Console.WriteLine(account4(sum, year));
                Console.ReadKey();
            }
            #endregion
            #region Talim kredit
            else if (UserChoice == "5")
            {
                Console.Clear();
                Console.Write("Miqdor kiriting>> ");

                double sum = double.Parse(Console.ReadLine()!);
                Console.Write("Necha yilga olmoqchisiz>> ");

                int year = int.Parse(Console.ReadLine()!);
                Account account5 = Kredit.Talim;

                Console.WriteLine(account5(sum, year));
                Console.ReadKey();
            }
            #endregion
            #region
            else if (UserChoice == "6")
            {
                Console.Clear();
                Console.WriteLine("Hizmatimizdan foydalanganingiz uchun rahmat!");
                break;
            }
            #endregion
            else { Console.WriteLine("Bunday tanlov yo'q!"); }
        }

    }
}