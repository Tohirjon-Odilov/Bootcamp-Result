namespace _17_lesson_DateTime_TimeStamp_File.Homework
{
    internal class SearchFile
    {
        public SearchFile() {
            try
            {
                Console.Write("Katalog nomini kiriting: ");
                string directoryPath = @"C:\Users\user\Desktop";

                string[] filePaths = FindFiles(directoryPath);
                Console.WriteLine(filePaths);
                if (filePaths.Length > 0)
                {
                    Console.WriteLine($"Topilgan fayllar:");
                    foreach (var filePath in filePaths)
                    {
                        Console.WriteLine(filePath);
                    }
                }
                else
                {
                    Console.WriteLine("Fayllar topilmadi!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xatolik yuz berdi: {ex.Message}");
            }
        }

        static string[] FindFiles(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            return files;
        }
    }
}

