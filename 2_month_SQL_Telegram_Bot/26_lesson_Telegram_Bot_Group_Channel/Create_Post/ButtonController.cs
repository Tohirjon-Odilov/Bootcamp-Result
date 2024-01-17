using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace _26_lesson_Telegram_Bot_Group_Channel
{
    public class ButtonController
    {
        public static async Task StartButton(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(
                new[]
            {
                new KeyboardButton[] { "create post" },
            }
                )

            {
                ResizeKeyboard = true
            };

            //await botClient.SendTextMessageAsync(
            //    chatId: update.Message.Chat.Id,
            //    text: "Yangi post yaratmoqchi bo'lsangiz, create_postni bosing.",
            //    replyMarkup: replyKeyboardMarkup,
            //    cancellationToken: cancellationToken);
        }
        public static async Task CreateButton(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
            new List<KeyboardButton[]>()
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("Channel name update"),
                    new KeyboardButton("Post text update"),
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Image update"),
                    new KeyboardButton("Link update")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("⬅️"),
                    new KeyboardButton("Save")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Send channel")
                }
            })
            {
                ResizeKeyboard = true,
            };
            //var buttonListOne = new List<InlineKeyboardButton>()
            //{
            //    new InlineKeyboardButton("ChanelName update"),
            //    new InlineKeyboardButton("PostText update")
            //};
            ////buttonListOne.Add(new InlineKeyboardButton("ChanelName update"));
            ////buttonListOne.Add(new InlineKeyboardButton("PostText update"));
            //var buttonListTwo = new List<InlineKeyboardButton>()
            //{
            //    new InlineKeyboardButton("Image update"),
            //    new InlineKeyboardButton("Link update")
            //};
            ////buttonListTwo.Add(new InlineKeyboardButton("Image update"));
            ////buttonListTwo.Add(new InlineKeyboardButton("Link update"));

            //var buttonListThree = new List<InlineKeyboardButton>()
            //{
            //    new InlineKeyboardButton("<-"),
            //    new InlineKeyboardButton("Save")
            //};
            //buttonListThree.Add(new InlineKeyboardButton("<-"));
            //buttonListThree.Add(new InlineKeyboardButton("Save"));
            //var buttonListFour = new List<InlineKeyboardButton>()
            //{
            //    new InlineKeyboardButton("Send Chanel")
            //};
            ////buttonListFour.Add(new InlineKeyboardButton("Send Chanel"));
            //buttons.Add(buttonListOne);
            //buttons.Add(buttonListTwo);
            //buttons.Add(buttonListThree);
            //buttons.Add(buttonListFour);


            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Yaxshi, keling unda boshlaymiz...",
                replyMarkup: replyKeyboard,
                cancellationToken: cancellationToken);
        }
        public static async Task EditButtons(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(
            new List<KeyboardButton[]>()
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("Edit channel name"),
                    new KeyboardButton("Edit post text update"),
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Edit image"),
                    new KeyboardButton("Edit link")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("⬅️"),
                    new KeyboardButton("Edit save")
            }})
            {
                ResizeKeyboard = true,
            };

            //var buttonsgorizontal1 = new List<KeyboardButton>();
            //buttonsgorizontal1.Add(new KeyboardButton("Edit ChanelName"));
            //buttonsgorizontal1.Add(new KeyboardButton("Edit PostText update"));
            //buttonsgorizontal1.Add(new KeyboardButton("Edit Image"));
            //buttonsgorizontal1.Add(new KeyboardButton("Edit Link"));
            //var buttonsgorizontal2 = new List<KeyboardButton>();
            //buttonsgorizontal2.Add(new KeyboardButton("⬅️"));
            //buttonsgorizontal2.Add(new KeyboardButton("Edit Save"));
            //inlineKeyboard.Add(buttonsgorizontal1);
            //inlineKeyboard.Add(buttonsgorizontal2);

            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "Yaxshi, keling davom etamiz...",
                replyMarkup: replyKeyboard,
                cancellationToken: cancellationToken);
        }
    }
}
