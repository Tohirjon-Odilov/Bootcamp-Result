using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using io = System.IO;

namespace _25_lesson_TelegramBot_Basic

{
    public class TelegramBot
    {
        TelegramBotClient botClient = new TelegramBotClient("6727219851:AAESLA1zoC3GMo-MvAVfoeqrjK438XoTf5g");
        public bool IsEnter { get; set; } = false;
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

            cts.Cancel();

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                try
                {
                    string jsonFilePath = "../../../users.json";
                    var dataList = io.File.ReadAllText(jsonFilePath);

                    List<Contact> list = JsonConvert.DeserializeObject<List<Contact>>(dataList);

                    foreach (var item in list)
                    {

                        if (item.UserId == update.Message.Chat.Id)
                        {
                            IsEnter = true;
                            break;
                        }
                        else
                        {
                            IsEnter = false;
                            if (update.Message.Contact is not null && item.PhoneNumber != update.Message.Contact.PhoneNumber)
                            {
                                list.Add(update.Message.Contact);

                                var data = io.File.ReadAllText(jsonFilePath);

                                list.Add(update.Message.Contact);

                                using (StreamWriter sw = new StreamWriter(jsonFilePath))
                                {
                                    sw.WriteLine(JsonConvert.SerializeObject(list, Formatting.Indented));
                                }
                                IsEnter = true;
                                break;
                            }
                        }
                    }
                    string allData = "";
                    HashSet<string> dublicateData = new HashSet<string>();
                    if (update.Message.Text == "/getall")
                    {
                        for (var i = 0; i < list.Count - 1; i++)
                        {
                            dublicateData.Add($"First Name: {list[i].FirstName}\nPhone Number: {list[i].PhoneNumber}\n\n");
                        }
                        foreach (var item in dublicateData)
                        {
                            allData += item;
                        }
                        var message = update.Message;
                        await botClient.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            replyToMessageId: message.MessageId,
                            text: allData,
                            cancellationToken: cancellationToken);
                    }
                    else if (update.Message.Text == "/getme")
                    {
                        foreach (var item in list)
                        {
                            if (item.UserId == update.Message.Chat.Id)
                            {
                                var message = update.Message;
                                await botClient.SendTextMessageAsync(
                                    chatId: message.Chat.Id,
                                    replyToMessageId: message.MessageId,
                                    text: $"First Name: {item.FirstName}\nPhone Number: {item.PhoneNumber}",
                                    cancellationToken: cancellationToken);
                                break;
                            }
                        }
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
