using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _28_lesson_instagram_downloader_bot_zipper_send_bot
{
    public class MessageController
    {
        public string VideoLink { get; set; }

        public async Task HandleMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine("HandleMessageAsync");
            var handler = update.Message.Type switch
            {
                MessageType.Text => TextAsyncFunction(botClient, update, cancellationToken),
                _ => OtherMessage(botClient, update, cancellationToken),
            };
        }

        private async Task TextAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // user'dan kelayotgan ma'lumot message'ga o'zlashadi aks holda dasturni return dsaturni to'xtadi
            if (update.Message is not { } message)
                return;

            // user'dan kelayotgan update.Message'dagi text messageText'ga o'zlashadi aks holda dasturni return dsaturni to'xtadi
            if (message.Text is not { } messageText)
                return;

            // user'dan kelayotgan update.Message'dagi chatId chatId'ga o'zlashadi istisno holatlar yo'q
            var chatId = update.Message.Chat.Id;

            Console.WriteLine($"Received a '{message.Text}' message in chat {chatId}. UserName =>  {message.Chat.Username}");
            //await botClient.SendVideoAsync(
            //           chatId: chatId,
            //           video: "https://smvd-videos-downloader.ugo-code-studio.workers.dev/download?t=aHR0cHM6Ly9zY29udGVudC5jZG5pbnN0YWdyYW0uY29tL3YvdDY2LjMwMTAwLTE2LzQzOTQ4MjEwXzE0MDE3MDM0NDc0NDI1NzdfNzMxNjcyMzk0OTUyMTgxMjkwNV9uLm1wND9lZmc9ZTMwJl9uY19odD1zY29udGVudC5jZG5pbnN0YWdyYW0uY29tJl9uY19jYXQ9MTA5Jl9uY19vaGM9VWNsMVVnRkVpNlFBWDg0Ti1hQiZlZG09QVBzMTdDVUJBQUFBJmNjYj03LTUmb2g9MDBfQWZDR1ZTQjlKS0lQYVViY1BsQTE2c3R6S3pWMGRMVTFzNl8zQkNBZmZqSGh3dyZvZT02NUIxNkNBOCZfbmNfc2lkPTEwZDEzYiZkbD0x&filename=text+video",
            //           replyToMessageId: message.MessageId,
            //           //supportsStreaming: true,
            //           cancellationToken: cancellationToken);
            //return;
            if (messageText.StartsWith("https://www.instagram.com"))
                try
                {
                    Console.WriteLine($"Message Type: {message.Type} Username=> {message.Chat.Username} Text => {message.Text} ");
                    //string originalUrl = "https://www.instagram.com/p/C0bXUHTo5HP/?utm_source=ig_web_copy_link";
                    //Console.WriteLine(encodedUrl);
                    //return;
                    Api root = new Api();

                    IList<Root> body = JsonConvert.DeserializeObject<IList<Root>>(root.RunApi(messageText).Result);

                    Console.WriteLine(body.Count);

                    foreach (var item in body)
                    {
                        Console.WriteLine($"\n{item.url}\n");
                        if (item.type == "video")
                        {
                            await botClient.SendChatActionAsync(
                                chatId: update.Message.Chat.Id,
                                chatAction: ChatAction.UploadVideo,
                                cancellationToken: cancellationToken
                            );
                            await botClient.SendVideoAsync(
                               chatId: chatId,
                               video: $"{item.url}",
                               replyToMessageId: message.MessageId,
                               supportsStreaming: true,
                               cancellationToken: cancellationToken);
                        }
                        else if (item.type == "photo")
                        {
                            await botClient.SendChatActionAsync(
                                chatId: update.Message.Chat.Id,
                                chatAction: ChatAction.UploadPhoto,
                                cancellationToken: cancellationToken
                            );
                            await botClient.SendPhotoAsync(
                               chatId: chatId,
                               replyToMessageId: message.MessageId,
                               photo: $"{item.url}",
                               cancellationToken: cancellationToken);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    await botClient.SendChatActionAsync(
                        chatId: message.Chat.Id,
                        chatAction: ChatAction.Typing,
                        cancellationToken: cancellationToken
                    );
                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: ex.Message,
                        replyToMessageId: message.MessageId,
                        cancellationToken: cancellationToken
                    );
                    string replasemessage = messageText.Replace("www.", "dd");
                    await botClient.SendVideoAsync
                    (
                           chatId: chatId,
                           video: $"{replasemessage}",
                           replyToMessageId: message.MessageId,
                           supportsStreaming: true,
                           cancellationToken: cancellationToken
                    );
                }
            else if (messageText.StartsWith("https://"))
            {
                await botClient.SendChatActionAsync(
                    chatId: message.Chat.Id,
                    chatAction: ChatAction.Typing,
                    cancellationToken: cancellationToken
                );
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Iltimos instagram link kiriting!",
                    replyToMessageId: message.MessageId,
                    cancellationToken: cancellationToken
                );
            }
            else
            {
                await botClient.SendChatActionAsync(
                     chatId: message.Chat.Id,
                     chatAction: ChatAction.Typing,
                     cancellationToken: cancellationToken
                 );
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Siz boshqa narsa kiritishga harakat qilyapsiz bloklanasiz!",
                    replyToMessageId: message.MessageId,
                    cancellationToken: cancellationToken
                );
            }
        }

        public async Task OtherMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendChatActionAsync(
                     chatId: update.Message.Chat.Id,
                     chatAction: ChatAction.Typing,
                     cancellationToken: cancellationToken
                 );
            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Siz boshqa narsa kiritib bug 🐞 chiqaradigan \nkimsalardek harakat qilyapsiz! 😡 \nIltimos instagram link tashlang!!!",
                replyToMessageId: update.Message.MessageId,
                cancellationToken: cancellationToken
            );
        }
    }
}
