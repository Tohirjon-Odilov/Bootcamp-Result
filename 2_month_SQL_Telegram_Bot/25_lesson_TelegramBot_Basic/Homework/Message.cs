using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace _25_lesson_TelegramBot_Basic
{
    public class Message
    {
        public static async Task MessageAsyncFunction(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken, bool isEnter)
        {
            var message = update.Message;
            Console.WriteLine($"You said: {message.Text}\nData: {DateTime.Now}\n");
            if (isEnter == true)
            {
                var handler = message.Type switch
                {
                    MessageType.Text => TextAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Photo => PhotoAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Video => VideoAsyncFunction(botClient, update, cancellationToken),
                    MessageType.VideoNote => VideoNoteAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Document => DopcumentAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Sticker => StikerAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Audio => AudioAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Voice => VoiceAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Animation => AnimationAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Poll => PollAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Contact => ContactAsyncFunction(botClient, update, cancellationToken),
                    _ => OtherAsyncFunctiob(botClient, update, cancellationToken)
                };
            }
            else
            {
                Contact(botClient, update, isEnter).Wait();
            }
        }

        static async Task ContactAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"Hush kelibsiz {message.Chat.FirstName}!",
                replyToMessageId: message.MessageId,
                replyMarkup: new ReplyKeyboardRemove()
                );
        }

        static async Task Contact(ITelegramBotClient botClient, Update update, bool isEnter)
        {
            Console.WriteLine(isEnter);
            ReplyKeyboardMarkup markup =
                        new ReplyKeyboardMarkup
                                (KeyboardButton.WithRequestContact("Kontact yuborish uchun tegining"));
            markup.ResizeKeyboard = true;
            await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Iltimos oldin telefon raqamingizni yuboring!",
                    replyMarkup: markup
            );

        }
        static async Task TextAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                text: "Ehe salomlar",
                cancellationToken: cancellationToken);
        }
        static async Task PhotoAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendPhotoAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                photo: InputFile.FromUri("https://www.pexels.com/photo/cable-car-in-narrow-old-town-street-19560870/"),
                cancellationToken: cancellationToken);
        }
        static async Task VideoAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendVideoAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                video: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-countdown.mp4"),
                //video: InputFile.FromStream(stream),
                supportsStreaming: true,
                cancellationToken: cancellationToken);
        }
        static async Task VideoNoteAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendVideoNoteAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                videoNote: InputFile.FromUri("https://www.pexels.com/video/drone-view-of-big-waves-rushing-to-the-shore-3571264/"),
                cancellationToken: cancellationToken);
        }
        static async Task DopcumentAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendDocumentAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                document: InputFile.FromFileId(message.Document!.FileId),
                cancellationToken: cancellationToken);
        }
        static async Task StikerAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendStickerAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                sticker: InputFile.FromFileId(message.Sticker!.FileId),
                cancellationToken: cancellationToken);
        }
        static async Task AudioAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendAudioAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                audio: InputFile.FromFileId(message.Audio!.FileId),
                cancellationToken: cancellationToken);
        }
        static async Task VoiceAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendVoiceAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                voice: InputFile.FromFileId(message.Voice!.FileId),
                cancellationToken: cancellationToken);
        }
        static async Task AnimationAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendAnimationAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                animation: InputFile.FromFileId(message.Animation!.FileId),
                cancellationToken: cancellationToken);
        }
        static async Task PollAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendPollAsync(
            chatId: update.Message.Chat.Id,
            question: "Meni kimligimni bilasizmi?",
            options: new[]
            {
                "Ha",
                "Yo'q"
            }
        );
        }
        static async Task OtherAsyncFunctiob(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                text: "Nimadir xato ketdi.",
                cancellationToken: cancellationToken);
        }

        public static async Task Unknown(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                text: "Spam bosma",
                cancellationToken: cancellationToken);
        }
    }
}
