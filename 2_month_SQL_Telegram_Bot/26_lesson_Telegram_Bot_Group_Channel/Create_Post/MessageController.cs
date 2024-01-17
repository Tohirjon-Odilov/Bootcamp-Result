using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace _26_lesson_Telegram_Bot_Group_Channel
{
    public class MessageController
    {
        public static string? PostText;
        public static string? ChannelName;
        public static string? Photo;
        public static string? Link;

        public static bool IsPostText = false;
        public static bool IsChannelName = false;
        public static bool IsPhoto = false;
        public static bool IsLink = false;

        public static async Task EssentialAsyncMessage(ITelegramBotClient botClient, Update? update, CancellationToken cancellationToken)
        {
            Task handler = update.Message.Type switch
            {
                MessageType.Text => TextAsyncFunction(botClient, update, cancellationToken),
                MessageType.Photo => PostPhotoAsyncFunction(botClient, update, cancellationToken),
                _ => OtherMessage(botClient, update, cancellationToken),
            };
        }
        public static async Task TextAsyncFunction(ITelegramBotClient botClient, Update? update, CancellationToken cancellationToken)
        {
            var message = update.Message.Text;
            if (message == "/start")
            {
                IsChannelName = false;
                IsPostText = false;
                IsPhoto = false;
                ChannelName = null; Photo = null; PostText = null;
                //await Butto   nController.StartButton(botClient, update, cancellationToken);

                await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                replyToMessageId: update.Message.MessageId,
                text: "Post quyidagi tartibda yaratiladi:\n\n" +
                "Chanelname update: kanal username'i.\n" +
                "Post update: matn uchun.\n" +
                "Image update: rasm joylash uchun.\n\n" +
                "BU MA'LUMOTLARNI TOLIQ KIRITMASANGIZ BOT ISHLAMAYDI!\n\n" +
                "/start => Qayta boshlash.\n" +
                "/create_post => Post yaratish uchun. \n" +
                "/see => Tayyor postni ko'rish.\n" +
                "/edit => Postni tahrirlash.\n",
                cancellationToken: cancellationToken);
            }
            else if (message == "/create_post")
            {
                await ButtonController.CreateButton(botClient, update, cancellationToken);
            }
            else if (message == "<-")
            {
                IsChannelName = false;
                IsPostText = false;
                IsPhoto = false;
                ChannelName = null; Photo = null; PostText = null;
            }
            else if (message == "/see")
            {
                await SeePost(botClient, update, cancellationToken);
            }
            else if (message == "/edit")
            {
                if (Photo != null && ChannelName != null && PostText != null)
                {
                    await ButtonController.EditButtons(botClient, update, cancellationToken);
                }
                else
                {
                    await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    replyToMessageId: update.Message.MessageId,
                    text: "Edit qilishingiz uchun postni yaratgan bolishingiz kerak!",
                    cancellationToken: cancellationToken);
                }
            }
            else if (message == "Send channel")
            {
                if (Photo != null && ChannelName != null && PostText != null)
                {
                    await botClient.SendPhotoAsync(
                        chatId: $"@{ChannelName}",
                        photo: InputFile.FromFileId(Photo),
                        caption: $"{PostText}\nKanalga o'ting: @{ChannelName}\n{Link}",
                        cancellationToken: cancellationToken);
                }
            }
            else if (message == "Channel name update" || message == "Edit username name")
            {
                IsChannelName = true;

                await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                replyToMessageId: update.Message.MessageId,
                text: "Kanal nomini kiriting!",
                cancellationToken: cancellationToken);
            }

            else if (message == "Post text update" || message == "Edit post text")
            {
                IsPostText = true;
                await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                replyToMessageId: update.Message.MessageId,
                text: "Post kiriting!",
                cancellationToken: cancellationToken);
            }

            else if (message == "Image update" || message == "Edit image")
            {
                IsPhoto = true;
                await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                replyToMessageId: update.Message.MessageId,
                text: "Rasm jo'nating!",
                cancellationToken: cancellationToken);
            }
            else if (message == "Link update" || message == "Edit link")
            {
                IsLink = true;
                await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                replyToMessageId: update.Message.MessageId,
                text: "Link jo'nating!",
                cancellationToken: cancellationToken);
            }
            else if (message == "Save" && IsChannelName && IsPostText && IsPhoto)
            {
                await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                replyToMessageId: update.Message.MessageId,
                text: "👌",
                cancellationToken: cancellationToken);
            }
            else
            {
                if (IsPostText)
                {
                    PostText = message;
                    IsPostText = false;
                    await botClient.SendTextMessageAsync
                    (
                       chatId: update.Message.Chat.Id,
                       replyToMessageId: update.Message.MessageId,
                       text: "Done",
                       cancellationToken: cancellationToken
                    );
                }
                else if (IsChannelName)
                {
                    ChannelName = message;
                    IsChannelName = false;
                    await botClient.SendTextMessageAsync
                    (
                       chatId: update.Message.Chat.Id,
                       replyToMessageId: update.Message.MessageId,
                       text: "Done",
                       cancellationToken: cancellationToken
                    );
                }
                else if (IsLink)
                {
                    Link = message;
                    IsLink = false;
                    await botClient.SendTextMessageAsync
                    (
                       chatId: update.Message.Chat.Id,
                       replyToMessageId: update.Message.MessageId,
                       text: "Done",
                       cancellationToken: cancellationToken
                    );
                }
                else
                {
                    return;
                }
            }

        }
        public static async Task PostPhotoAsyncFunction(ITelegramBotClient botClient, Update? update, CancellationToken cancellationToken)
        {
            if (IsPhoto)
            {
                Photo = update.Message.Photo.Last().FileId;
                IsPhoto = false;
                await botClient.SendTextMessageAsync
                (
                   chatId: update.Message.Chat.Id,
                   replyToMessageId: update.Message.MessageId,
                   text: "Done",
                   cancellationToken: cancellationToken
                );
            }
        }
        public static async Task OtherMessage(ITelegramBotClient botClient, Update? update, CancellationToken cancellationToken)
        {
            return;
        }
        public static async Task SeePost(ITelegramBotClient botClient, Update? update, CancellationToken cancellationToken)
        {
            if (Photo == null)
            {
                if (ChannelName != null && PostText != null)
                {
                    var message = update.Message;
                    await botClient.SendTextMessageAsync
                    (
                        chatId: message.Chat.Id,
                        disableNotification: true,
                        replyToMessageId: message.MessageId,
                        text: $"{PostText}\nKanalga o'ting: @{ChannelName}\n{Link}",
                        replyMarkup: new ReplyKeyboardRemove(),
                        cancellationToken: cancellationToken
                    );
                }
            }

            else
            {
                if (ChannelName != null && PostText != null)
                {
                    var message = update.Message;
                    await botClient.SendPhotoAsync
                    (
                        chatId: message.Chat.Id,
                        disableNotification: true,
                        replyToMessageId: message.MessageId,
                        caption: $"{PostText}\nKanalga o'ting: @{ChannelName}\n{Link}",
                        photo: InputFile.FromFileId(Photo),
                        replyMarkup: new ReplyKeyboardRemove(),
                        cancellationToken: cancellationToken
                    );
                }
            }
        }
    }
}
