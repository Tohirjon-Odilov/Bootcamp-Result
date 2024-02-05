using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection.Metadata;
public class PDF
{
    private static void Main(string[] args)
    {

        DirectoryInfo projectDirectoryInfo =
          Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;

        Console.WriteLine(projectDirectoryInfo.FullName);

        string pdfsFolder = Directory.CreateDirectory(
             Path.Combine(projectDirectoryInfo.FullName, "pdfs")).FullName;

        QuestPDF.Settings.License = LicenseType.Community;
        // code in your main method
        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(20));

                page.Header()
                  .Text("Hello PDF!")
                  .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                page.Content()
                  .PaddingVertical(1, Unit.Centimetre)
                  .Column(x =>
                  {
                      x.Spacing(20);

                      x.Item().Text("Hello from Sarvarbek Bakhtiyorov.");
                  });

                page.Footer()
                  .AlignCenter()
                  .Text(x =>
                  {
                      x.Span("Page ");
                      x.CurrentPageNumber();
                  });
            });
        })
        .GeneratePdf(Path.Combine(pdfsFolder, "hello-from-sarvarbek.pdf"));
    }
}
