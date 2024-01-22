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

            #region mock
            //Console.WriteLine("Boshi");
            //await botClient.SendAudioAsync(
            //           chatId: chatId,
            //           audio: messageText,
            //           replyToMessageId: message.MessageId,
            //           //supportsStreaming: true,
            //           cancellationToken: cancellationToken);
            //Console.WriteLine("Oxiri");
            //return;
            #endregion
            if (messageText == "/start")
            {
                Console.WriteLine($"Xush kelibsiz {message.Chat.Username}! Instagram link yuborishingiz mumkin.");
            }
            else if (messageText.StartsWith("https://www.instagram.com"))
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
                            MyChatAction.Uploading(botClient, update, cancellationToken);

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

                    MyChatAction.Typing(botClient, update, cancellationToken);

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
                MyChatAction.Typing(botClient, update, cancellationToken);

                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Iltimos instagram link kiriting!",
                    replyToMessageId: message.MessageId,
                    cancellationToken: cancellationToken
                );
            }
            else
            {
                MyChatAction.Typing(botClient, update, cancellationToken);

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
            MyChatAction.Typing(botClient, update, cancellationToken);

            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Siz boshqa narsa kiritib bug 🐞 chiqaradigan \nkimsalardek harakat qilyapsiz! 😡 \nIltimos instagram link tashlang!!!",
                replyToMessageId: update.Message.MessageId,
                cancellationToken: cancellationToken
            );
        }
    }
}
