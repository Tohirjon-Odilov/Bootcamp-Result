using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _24_lesson_Takrorlash_Telegram_bot;

public class Translate
{
    private string target { get; set; }
    private string source { get; set; }
    private string text { get; set; }
    private string result { get; set; }

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

            //if (target != null && source != null && text != null)
            //{
            try
            {
                result = renderMessage(messageText.Split()[0], messageText.Split()[1], messageText.Split()[2]);
                //    Message sentMessage = await botClient.SendTextMessageAsync(
                //        chatId: chatId,
                //        text: $"{result}",
                //        cancellationToken: cancellationToken);
                //}
                //else if (target != null)
                //{
                //    target = messageText;
                //}
                //else if (source != null)
                //{
                //    source = messageText;
                //}
                //else if (text != null)
                //{
                //    text = messageText;
                //}
                //else if (messageText == "uz")
                //{
                //    Message sentMessage = await botClient.SendTextMessageAsync(
                //        chatId: chatId,
                //        text: $"o'xshadi",
                //        cancellationToken: cancellationToken);
                //}

                //Console.WriteLine($"Received '{messageText}' message in chat {chatId}.");
                //Message sentMessage = await botClient.SendTextMessageAsync(
                //    chatId: chatId,
                //    text: result,
                //    cancellationToken: cancellationToken);

                Message wordWithImg = await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: InputFile.FromUri($"https://www.pexels.com/search/{result}/"),
                    caption: $"<b>{message}</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
                    //caption: $"<b></b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);


                //Console.WriteLine(target, source, text);
                //renderMessage();
                // Echo received message text
                //if (messageText == "about")
                //{
                //Message sentMessage1 = await botClient.SendTextMessageAsync(
                //    chatId: chatId,
                //    text: $"{target}{source}{text}",
                //    cancellationToken: cancellationToken);
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
            catch (IndexOutOfRangeException)
            {
                Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: $"Ma'lumotni `en uz hello` shu ko'rinishda kiriting!",
                    cancellationToken: cancellationToken);
            }
            catch (AggregateException)
            {
                Message wordWithImg = await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: InputFile.FromUri($"https://www.pexels.com/search/{messageText.Split()[2]}/"),
                    caption: $"<b>API'da limit tugadi. Shu sababli tarjima kelmadi.</b> <i>Source</i>: <a href=\"https://pixabay.com\"></a>",
                    //caption: $"<b></b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine("va xatolik chiqdi");
                Console.WriteLine(ex);
            }
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

    private string renderMessage(string source, string target, string text)
    {
        string? translatedData = Server.Translate(target, source, text).Result;
        Root data = JsonSerializer.Deserialize<Root>(translatedData)!;
        return data.data.translations[0].translatedText;

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