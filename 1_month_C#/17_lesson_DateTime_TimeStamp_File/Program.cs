        //using Spectre.Console; // To use Table.
using Spectre.Console;

namespace _17_lesson_DateTime_TimeStamp_File
{
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //2003 20 fevral Sardor Ustoz
    //        //2001 06 07 Ustoz Sarvar aka
    //        //1998 04 29 Dilshod aka
    //        //Console.Write("Enter your birthday: ");
    //        //DateTime countAgeDay = Convert.ToDateTime(Console.ReadLine());
    //        DateTime countAgeDay = new DateTime(2007, 06, 11);
    //        DateTime now = DateTime.Now;
    //        WriteLine((now - countAgeDay).Days);
    //    }
public class Program
    {
        private static void SectionTitle(string title)
        {
            WriteLine(title);
            ConsoleColor previousColor = ForegroundColor;
            // Use a color that stands out on your system.
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($"*** {title} ***");
            ForegroundColor = previousColor;
        }

        private static void Main(string[] args)
        {
            SectionTitle("Handling cross-platform environments and filesystems");
            // Create a Spectre Console table.
            Table table = new();
            // Add two columns with markup for colors.
            table.AddColumn("[blue]MEMBER[/]");
            table.AddColumn("[blue]VALUE[/]");
            // Add rows.
            table.AddRow("Path.PathSeparator", PathSeparator.ToString());
            table.AddRow("Path.DirectorySeparatorChar",
            DirectorySeparatorChar.ToString());
            table.AddRow("Directory.GetCurrentDirectory()",
            GetCurrentDirectory());
            table.AddRow("Environment.CurrentDirectory", CurrentDirectory);
            table.AddRow("Environment.SystemDirectory", SystemDirectory);
            table.AddRow("Path.GetTempPath()", GetTempPath());
            table.AddRow("");
            table.AddRow("GetFolderPath(SpecialFolder", "");
            table.AddRow(" .System)", GetFolderPath(SpecialFolder.System));
            table.AddRow(" .ApplicationData)",
            GetFolderPath(SpecialFolder.ApplicationData));
            table.AddRow(" .MyDocuments)",
            GetFolderPath(SpecialFolder.MyDocuments));
            table.AddRow(" .Personal)",
            GetFolderPath(SpecialFolder.Personal));
            // Render the table to the console
            AnsiConsole.Write(table);
        }
    }

//}
}
