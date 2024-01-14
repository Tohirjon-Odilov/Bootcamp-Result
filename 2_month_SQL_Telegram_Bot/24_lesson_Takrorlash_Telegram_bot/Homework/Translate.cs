using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _24_lesson_Takrorlash_Telegram_bot;

public class Translate
{
    public async Task FirstMessage()
    {
        var botClient = new TelegramBotClient("6602415427:AAG9kKH0HVIgZ3zliZP7_0sRqFMha4_uOLg");

        using CancellationTokenSource cts = new();

        // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
        ReceiverOptions receiverOptions = new()
        {
            AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
        };

        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        var me = await botClient.GetMeAsync();

        Console.WriteLine($"Start listening for @{me.Username}");
        Console.ReadLine();

        // Send cancellation request to stop bot
        cts.Cancel();

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return;
            // Only process text messages
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;

            Console.WriteLine($"Received '{messageText}' message in chat {chatId}.");
            //renderMessage();
            // Echo received message text
            //if (messageText == "about")
            //{
            //    Message sentMessage = await botClient.SendTextMessageAsync(
            //        chatId: chatId,
            //        text: $"Hello, {message.Chat.LastName}",
            //        cancellationToken: cancellationToken);
            //}
            //else if (messageText == "sticker")
            //{
            //    Message sentSticker = await botClient.SendStickerAsync(
            //        chatId: chatId,
            //        sticker: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"),
            //        cancellationToken: cancellationToken);
            //}
            //else if (messageText == "video")
            //{
            //    Message sentVideo = await botClient.SendVideoAsync(
            //        chatId: chatId,
            //        video: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/video-bulb.mp4"),
            //        cancellationToken: cancellationToken);
            //}
            //else if (messageText == "markdown")
            //{
            //    Message markDown = await botClient.SendTextMessageAsync(
            //        chatId: chatId,
            //        text: "Trying *all the parameters* of `sendMessage` method",
            //        parseMode: ParseMode.MarkdownV2,
            //        disableNotification: false,
            //        replyToMessageId: update.Message.MessageId,
            //        replyMarkup: new InlineKeyboardMarkup(
            //            InlineKeyboardButton.WithUrl(
            //                text: "Check sendMessage method",
            //                url: "https://core.telegram.org/bots/api#sendmessage")),
            //        cancellationToken: cancellationToken);
            //}
        }

        Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

    }

    private Root renderMessage(string target, string source, string text)
    {
        if (target != null && source != null && text != null)
        {
            string? translatedData = Server.Translate(target, source, text).Result;
            Root data = JsonSerializer.Deserialize<Root>(translatedData);
            return data;
        }
        else
        {
            return new Root();
        }


        #region tez orada
        //var languageDetect = Server.DetectLanguage("nima gaplar").Result;
        //Console.WriteLine(languageDetect);
        //DetectMadel detectMadel = new DetectMadel();
        //var data = JsonSerializer.Deserialize<Root>(languageDetect);
        //Console.WriteLine(data.data);

        //JObject data = JObject.Parse(languageDetect);
        //Console.WriteLine(data["data"]);
        //foreach (var item in data)
        //{
        //    Console.WriteLine(item[]);
        //}

        //var languagesCode = Server.LanguagesCode("uz").Result;

        //Console.WriteLine(data.data.translations[0].translatedText);

        #endregion
    }

}