﻿using _24_lesson_Takrorlash_Telegram_bot;
// https://t.me/own_translate_bot shu bot'ga kirish kerak
// https://www.pexels.com/search/bird/ rasmlar olish uchun


// telegram bot "uz eng Hello" shu tartibda yoziladi
//var result = 

Translate result = new Translate();
try
{
    result.FirstMessage().Wait();
}
catch (Exception)
{
    throw new Exception("Nimadir xato ketdi.");
}

//FirstTelegramBot bot = new FirstTelegramBot();
//bot.ReplayMessage().Wait();