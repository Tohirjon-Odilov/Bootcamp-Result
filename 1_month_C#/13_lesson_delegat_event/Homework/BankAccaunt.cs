using Bank;

public class BankAccaunt
{
    public delegate double MyBankAccaunt(double sum, int years);
    public static void Main(string[] args)
    {

        Kredit kredit = new Kredit();

        #region Ipoteka
        Console.WriteLine("Enter sum ipoteka ");
        double sumipoteka = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter years ipoteka ");
        int yearsipoteka = int.Parse(Console.ReadLine()!);
        MyBankAccaunt account = kredit.Ipoteka;
        Console.WriteLine(account(sumipoteka, yearsipoteka));
        #endregion

        #region Mashina
        Console.WriteLine("Enter sum mashina ");
        double summashina = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter years mashina ");
        int yearsmashina = int.Parse(Console.ReadLine()!);
        MyBankAccaunt account2 = kredit.Mashina;
        Console.WriteLine(account2(summashina, yearsmashina));
        #endregion

        #region Maqsadsiz kridit
        Console.WriteLine("Enter sum maqsadsiz kridit ");
        double summaqsadsizkr = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter years maqsadsiz kridit ");
        int yearsmaqsadsizkr = int.Parse(Console.ReadLine()!);
        MyBankAccaunt account3 = kredit.Maqsadsizkr;
        Console.WriteLine(account3(summaqsadsizkr, yearsmaqsadsizkr)); ;
        #endregion

        #region Imtiyozli kridit
        Console.WriteLine("Enter sum imtiyozli kridit ");
        double sumimtiyozli = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter years imtiyozli kridit ");
        int yearsimtiyozli = int.Parse(Console.ReadLine()!);
        MyBankAccaunt account4 = kredit.Imtiyozli;
        Console.WriteLine(account4(sumimtiyozli, yearsimtiyozli));
        #endregion

        #region Talim kridit
        Console.WriteLine("Enter sum talim kridit  ");
        double sumtalim = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter years talim kridit ");
        int yearstalim = int.Parse(Console.ReadLine()!);
        MyBankAccaunt account5 = kredit.Talimkd;
        Console.WriteLine(account5(sumtalim, yearstalim));
        #endregion

    }
}