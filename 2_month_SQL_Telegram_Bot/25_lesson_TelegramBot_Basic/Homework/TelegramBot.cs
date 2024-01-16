using _25_lesson_TelegramBot_Basic.Homework;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _25_lesson_TelegramBot_Basic

{
    public class TelegramBot
    {
        TelegramBotClient botClient = new TelegramBotClient("6727219851:AAESLA1zoC3GMo-MvAVfoeqrjK438XoTf5g");
        public bool IsEnter { get; set; } = false;
        public List<UserMadel>? userMadel { get; set; }
        public async Task MainFunction()
        {
            using CancellationTokenSource cts = new();
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
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
            var data = System.IO.File.ReadAllText("../../../users.json");
            List<UserMadel> list = JsonConvert.DeserializeObject<List<UserMadel>>(data);
            userMadel = list;
            cts.Cancel();

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                try
                {
                    //userMadel.Add(contact);
                    List<Contact> dataList = new List<Contact>();
                    if (update.Message.Contact is not null)
                    {
                        dataList.Add(update.Message.Contact);
                        string jsonFilePath = "../../../users.json";
                        IsEnter = true;
                        string jsonToString = JsonConvert.SerializeObject(update.Message.Contact, Formatting.Indented);
                        System.IO.File.WriteAllText(jsonFilePath, jsonToString);
                    }

                    var handler = update.Type switch
                    {
                        UpdateType.Message => Message.MessageAsyncFunction(botClient, update, cancellationToken, IsEnter),
                        _ => Message.MessageAsyncFunction(botClient, update, cancellationToken, IsEnter),
                    };
                }
                catch (Exception e)
                {
                    var handler = update.Type switch
                    {
                        UpdateType.Message => Message.Unknown(botClient, update, cancellationToken),
                        _ => Message.Unknown(botClient, update, cancellationToken),
                    };
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
    }
}
