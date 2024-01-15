using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace _25_lesson_TelegramBot_Basic
{
    public partial class Basic
    {

        public async Task HandleTextMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sendMessage = await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                text: message.Text,
                cancellationToken: cancellationToken
                );

            Console.WriteLine(value: "text");

        }

        public async Task HandleVideoMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendVideoAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                video: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-countdown.mp4"),
                supportsStreaming: true,
                cancellationToken: cancellationToken);
        }

        public async Task HandleAudioMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendAudioAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                audio: InputFile.FromFileId(message.Audio!.FileId),
                cancellationToken: cancellationToken);
            Console.WriteLine("audio");

        }

        public async Task HandleStickerMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendStickerAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                sticker: InputFile.FromFileId(message.Sticker!.FileId),
                cancellationToken: cancellationToken);
            Console.WriteLine("stiker");
        }

        public async Task HandlePhotoMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendPhotoAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                photo: InputFile.FromUri("https://media.istockphoto.com/id/1299986427/photo/silhouette-of-asian-woman-standing-against-dark-corridor-in-a-park.jpg?s=612x612&w=0&k=20&c=QEAmWtDh8gK8b2hCy98GLQf2XR7vwImyNmPP2lszWRs="),
                cancellationToken: cancellationToken);
        }

        public async Task HandleContactMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            ReplyKeyboardMarkup markup =
                    new ReplyKeyboardMarkup
                            (KeyboardButton.WithRequestContact("Telefon raqam yuborish"));
            markup.ResizeKeyboard = true;
            Message test = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Contact",
                    replyMarkup: markup
            );

        }

        public async Task HandleDocumentMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendDocumentAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                document: InputFile.FromFileId(message.Document!.FileId),
                cancellationToken: cancellationToken);
        }

        public async Task HandleLocationMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sendMessage = await botClient.SendVenueAsync(
                chatId: chatId,
                latitude: 50.0840172f,
                longitude: 14.418288f,
                title: "Man Hanging out",
                address: "Husova, 110 00 Staré Město, Czechia",
                cancellationToken: cancellationToken);

        }

        public async Task HandlePollMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendPollAsync(
            chatId: update.Message.Chat.Id,
            question: "C# qiziqroqmi?",
            options: new[]
            {
                "Ha",
                "Yo'q"
            });
        }

        public async Task HandleVoiceMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendVoiceAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                voice: InputFile.FromFileId(message.Voice!.FileId),
                cancellationToken: cancellationToken);
        }

        public async Task HandleMessagePinnedMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                replyToMessageId: message.MessageId,
                text: $"Siz '{message.Text}' ushbu xabarni pin qildingiz",
                cancellationToken: cancellationToken
                );
        }

        public async Task HandleUnknownMessageTypeAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                text: "Siz umuman boshqa narsa kiritdingiz!",
                cancellationToken: cancellationToken);
        }

    }
}
