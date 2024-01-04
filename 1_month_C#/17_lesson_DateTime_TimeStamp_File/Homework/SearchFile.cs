namespace _17_lesson_DateTime_TimeStamp_File.Homework
{
    internal class SearchFile
    {
        public SearchFile()
        {

            Console.Write("Enter file name: ");
            string FileName = Console.ReadLine()!;

            List<string> Result = new List<string>();
            DriveInfo[] Disks = DriveInfo.GetDrives();
            for (int i = 0; i < Disks.Length; i++)
            {
                Search(Result, Convert.ToString(Disks[i])!, FileName);
            }

            Console.WriteLine("Resoult: ");
            foreach (string f in Result)
                Console.WriteLine(f);
        }
        public void Search(List<string> notFound, string Path, string FilesName)
        {
            string[] Files = Directory.GetFiles(Path);
            foreach (string f in Files)
            {
                string[] filenomi = f.Split('\\');
                if (filenomi[filenomi.Length - 1] == FilesName)
                    notFound.Add(f);
            }


            string[] folders = Directory.GetDirectories(Path);
            foreach (string f in folders)
            {

                try
                {
                    Search(notFound, f, FilesName);
                }
                catch { }
            }

        }


    }
}

