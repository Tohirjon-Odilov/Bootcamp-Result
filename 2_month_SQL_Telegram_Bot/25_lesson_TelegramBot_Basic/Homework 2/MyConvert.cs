using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

public class MyConvert
{

    public async Task ReplayMessage()
    {
        // api'dan kelayotgan ma'lumotlar
        //HttpClient httpClient = new HttpClient();
        //var request = new HttpRequestMessage(HttpMethod.Get, "https://nbu.uz/exchange-rates/json/");
        //var response = await httpClient.SendAsync(request);
        //string Body = await response.Content.ReadAsStringAsync();
        //var courses = JsonSerializer.Deserialize<List<Valyuta>>(Body)!;



        var botClient = new TelegramBotClient("6923035570:AAGf7g5CDEkWqFhxtrYuIs5VaoUwWTKVhhE");

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

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");


            //if (messageText == "/start")
            //{

            //Message test = await botClient.SendTextMessageAsync(
            //        chatId: 2016634633,
            //        text: "Contact",
            //        replyMarkup: markup
            //);

            //foreach (var item in courses)
            //{
            //if (item.code == "USD")
            //{
            // ReplyKeyboardMarkup markup = new ReplyKeyboardMarkup
            //(
            //    KeyboardButton.WithRequestContact("USD")
            //);
            //markup.ResizeKeyboard = true;
            Message test = await botClient.SendTextMessageAsync(
                    chatId: 2016634633,
                    text: "Contact",
                    cancellationToken: cancellationToken
            );
            //}
            //}
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

