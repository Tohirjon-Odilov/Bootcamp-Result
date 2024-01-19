using System.IO.Compression;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace _27_lesson_TelegramBot_keyboard_inlineKeyboard
{
    public class ZipperFile
    {
        private bool isEnter = false;

        public async Task Server()
        {

            var botClient = new TelegramBotClient("Your token");

            using CancellationTokenSource cts = new();

            HashSet<long> users = new HashSet<long>();
            string? fileName = null;
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
                var handler = update.Type switch
                {
                    UpdateType.Message => HandleMessageAsync(botClient, update, cancellationToken),
                    _ => HandleUnknownUpdateType(botClient, update, cancellationToken),
                };
            }

            async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                //return;
                var message = update.Message;
                var user = message.Chat.FirstName;
                var handler = message.Type switch
                {
                    MessageType.Text => HandleTextMessageAsync(botClient, update, cancellationToken),
                    _ => HandleUnknownMessageTypeAsync(update, update, cancellationToken),
                };
            }

            async Task HandleTextMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                //return;
                if (update.Message.Text == "/start")
                {
                    users.Add(update.Message.Chat.Id);
                    isEnter = true;
                    ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                    {
                    new KeyboardButton[] { "Enter path!"},
                    new KeyboardButton[] {"Change Start path!"}
                })
                    {
                        ResizeKeyboard = true
                    };

                    Message sentMessage = await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "Choose a response",
                        replyMarkup: replyKeyboardMarkup,
                        cancellationToken: cancellationToken);
                }

                else if (update.Message.Text == "Path kiriting!")
                {
                    await botClient.SendTextMessageAsync(
                         chatId: update.Message.Chat.Id,
                         text: @"Masalan: C:\Users\Tohirjon\Desktop\Hack_Data",
                         cancellationToken: cancellationToken
                         );
                }

                else if (update.Message.Text.StartsWith("D:") || update.Message.Text.StartsWith("C:") || update.Message.Text.StartsWith("E:") && isEnter)
                {
                    string path = update.Message.Text;
                    if (System.IO.Directory.Exists(path) == true)
                    {
                        string startPath = $@"{path}";
                        var arr = path.Split(@"\");
                        string zipPath = $@"C:\Users\Tohirjon\Desktop\Hack_Data\{arr[arr.Length - 1]}.zip";
                        try
                        {
                            if (System.IO.File.Exists(zipPath) == false)
                            {
                                ZipFile.CreateFromDirectory(startPath, zipPath);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }

                        foreach (long item in users)
                        {
                            await botClient.SendChatActionAsync(
                                chatId: update.Message.Chat.Id,
                                chatAction: ChatAction.UploadDocument,
                                cancellationToken: cancellationToken
                            );

                            await using Stream stream = System.IO.File.OpenRead($"{zipPath}");
                            Message message = await botClient.SendDocumentAsync(
                                chatId: item,
                                document: InputFile.FromStream(stream: stream, fileName: $"{arr[arr.Length - 1]}.zip"),
                                caption: "Hack");
                            Console.WriteLine(arr[arr.Length - 1]);
                        }
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(
                            chatId: update.Message.Chat.Id,
                            text: "Such path not found Error!",
                            cancellationToken: cancellationToken
                            );
                    }
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

            async Task HandleUnknownUpdateType(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                Console.WriteLine("Boshqa narsa yuborildi");
            }
        }

        private async Task HandleUnknownMessageTypeAsync(Update update1, Update update2, CancellationToken cancellationToken)
        {
            Console.WriteLine("Boshqa narsa yuborildi");
        }
    }
}
