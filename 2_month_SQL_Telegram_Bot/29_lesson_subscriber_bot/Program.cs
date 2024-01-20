using _29_lesson_subscriber_bot;

var token = "6411480447:AAGUJk-IK5YKn7J1ZOFUJqKzp0g3r5WOF8Y";
Server server = new Server(token);
try
{
    server.Run().Wait();
}
catch (Exception ex)
{
    Console.WriteLine($"Program => {ex.Message}");
}