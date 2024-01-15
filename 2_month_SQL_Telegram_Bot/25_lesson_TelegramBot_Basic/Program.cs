using _25_lesson_TelegramBot_Basic;

TelegramBot bot = new TelegramBot();
try
{
    await bot.MainFunction();
}
catch (Exception)
{
    Console.WriteLine("Vay");
}


//MyConvert convert = new MyConvert();
//try
//{
//    convert.ReplayMessage().Wait();
//}
//catch (Exception)
//{
//    throw new Exception("Voyey");
//}