// 6560962263:AAHOhhhUy6eSDvD3yVAbn7vDIFgp-b4P-Go 
// @how_to_compress_file_bot

using _27_lesson_TelegramBot_keyboard_inlineKeyboard;
try
{
    ZipperFile server = new ZipperFile();

    await server.Server();
}
catch (Exception ex)
{
    Console.WriteLine($"Error chiqdi -> {ex.Message}");
}
//CompressFile file = new CompressFile();
//file.Zip();
