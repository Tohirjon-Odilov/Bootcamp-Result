using _25_lesson_TelegramBot_Basic;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

public class MyConvert
{
    public async Task ReplayMessage()
    {
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

            var handler = update.Type switch
            {
                UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken),
                UpdateType.CallbackQuery => HandleCallBackQueryAsync(botClient, update, cancellationToken),
                UpdateType.EditedMessage => HandleEditedMessageAsync(botClient, update, cancellationToken),
                //UpdateType.CallbackQuery =>HandleMessageAsync(botClient, update, cancellationToken),
                _ => HandleUnknownUpdateType(botClient, update, cancellationToken),
            };
        }
        async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            var user = message.Chat.FirstName;
            var handler = message.Type switch
            {
                MessageType.Text => HandleTextMessageAsync(botClient, update, cancellationToken, user),

                _ => HandleUnknownMessageTypeAsync(update, update, cancellationToken),
            };
        }
        async Task HandleTextMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, string user)
        {
            var chatName = update.Message.Chat.FirstName;
            var messageText = update.Message.Text;
            Console.WriteLine($"Received a '{messageText}' message in chat {chatName}.");

            // Echo received message text
            HttpClient lets = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://nbu.uz/exchange-rates/json/");
            var response = await lets.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            var courses = JsonConvert.DeserializeObject<List<Valyuta>>(body);
            var buttons = new List<List<InlineKeyboardButton>>();
            var button = new List<InlineKeyboardButton>();
            var button1 = new List<InlineKeyboardButton>();
            var button2 = new List<InlineKeyboardButton>();
            var button3 = new List<InlineKeyboardButton>();
            byte count = 1;

            foreach (Valyuta item in courses)
            {
                if (button.Count != 6)
                {
                    button.Add(InlineKeyboardButton.WithCallbackData($"{item.code}", $"{item.cb_price}"));
                }
                else if (button1.Count != 6)
                {
                    button1.Add(InlineKeyboardButton.WithCallbackData($"{item.code}", $"{item.cb_price}"));
                }
                else if (button2.Count != 6)
                {
                    button2.Add(InlineKeyboardButton.WithCallbackData($"{item.code}", $"{item.cb_price}"));
                }
                else if (button3.Count != 6)
                {
                    button3.Add(InlineKeyboardButton.WithCallbackData($"{item.code}", $"{item.cb_price}"));
                }
            }
            buttons.Add(button);
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);

            Telegram.Bot.Types.Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Valyuta nomini tanlang!",
                replyMarkup: new InlineKeyboardMarkup(buttons),
                cancellationToken: cancellationToken);
        }
        async Task HandleCallBackQueryAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.CallbackQuery.Data != null)
            {
                string a = update.CallbackQuery.Data.ToString();
                await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.From.Id,
                     text: $"{a}",
                     cancellationToken: cancellationToken);
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

        Task HandleEditedMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task HandleUnknownMessageTypeAsync(Update update1, Update update2, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task HandleUnknownUpdateType(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

