//string startPath = @".\start";
//string zipPath = @".\result.zip";
//string extractPath = @".\extract";

//ZipFile.CreateFromDirectory(startPath, zipPath);
//ZipFile.ExtractToDirectory(zipPath, extractPath);

using System.IO.Compression;

namespace _27_lesson_TelegramBot_keyboard_inlineKeyboard
{
    public class CompressFile
    {
        public static string Zip(string path)
        {
            string startPath = @"path";
            string zipPath = @"C:\Users\Tohirjon\Desktop\TestFile\result.zip";
            try
            {
                ZipFile.CreateFromDirectory(startPath, zipPath);
                return zipPath;
            }
            catch (Exception e)
            {
                return zipPath;
                Console.WriteLine(e.Message);
            }
        }
    }
}
