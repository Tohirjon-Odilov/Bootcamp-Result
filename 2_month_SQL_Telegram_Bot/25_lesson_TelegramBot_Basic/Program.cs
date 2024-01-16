using _25_lesson_TelegramBot_Basic;

try
{
    TelegramBot bot = new TelegramBot();
    await bot.MainFunction();
}
catch (NullReferenceException)
{
    throw new Exception("Vay vay vay");
}
catch (Exception)
{
    throw new Exception("Nima bo'ldi");
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