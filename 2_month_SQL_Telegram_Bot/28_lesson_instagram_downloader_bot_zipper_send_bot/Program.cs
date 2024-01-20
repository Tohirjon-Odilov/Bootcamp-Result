using _28_lesson_instagram_downloader_bot_zipper_send_bot;
// 6827225607:AAHMZ2m1n61NuZq7FBq1dkpklz0jJknsJQk
var token = "6411480447:AAGUJk-IK5YKn7J1ZOFUJqKzp0g3r5WOF8Y";
Server server = new Server(token);
try
{
    server.Run().Wait();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}