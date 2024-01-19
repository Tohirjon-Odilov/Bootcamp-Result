using _28_lesson_instagram_downloader_bot_zipper_send_bot;
// 6827225607:AAHMZ2m1n61NuZq7FBq1dkpklz0jJknsJQk
var token = "6727219851:AAESLA1zoC3GMo-MvAVfoeqrjK438XoTf5g";
Server server = new Server(token);
try
{
    server.Run().Wait();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}