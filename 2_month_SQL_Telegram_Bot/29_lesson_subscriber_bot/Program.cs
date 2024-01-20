using _29_lesson_subscriber_bot;

var token = "6814085088:AAEiOlIocad539Prf9MWiMv5cFzqB1nE8WQ";
Server server = new Server(token);
try
{
    server.Run().Wait();
}
catch (Exception ex)
{
    Console.WriteLine($"Program => {ex.Message}");
}