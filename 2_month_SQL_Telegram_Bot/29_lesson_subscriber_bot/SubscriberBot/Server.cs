﻿using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace _29_lesson_subscriber_bot
{
    public class Server
    {
        public string Token { get; set; }
        public Server(string token)
        {
            Token = token;
        }
        public async Task Run()
        {
            var botClient = new TelegramBotClient($"{Token}");

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
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            //return;
            try
            {
                if (update.Message is not { } message) return;
                if (message.Chat is not { } chat) return;

                // Foydalanuvchining chat id'sini olish
                long userId = chat.Id;

                Console.WriteLine($"{userId} => {chat.Username} => {chat.Username}");

                // Kanalning username'sini o'zgartiring
                string channelUsername1 = "@code_en";
                string channelUsername2 = "@N11_Telegram";

                // Foydalanuvchini tekshirish
                var chatMember1 = await botClient.GetChatMemberAsync(channelUsername1, userId);
                var chatMember2 = await botClient.GetChatMemberAsync($"{channelUsername2}", userId);
                Console.WriteLine(chatMember1.ToString());
                Console.WriteLine(chatMember2.ToString());

                // Agar foydalanuvchi kanalda obuna bo'lsa
                if (chatMember1.Status == ChatMemberStatus.Member && chatMember2.Status == ChatMemberStatus.Member)
                {
                    Console.WriteLine($"User -> {message.Chat.FirstName} Chat Id -> {message.Chat.Id}\nMessage ->{message.Text}\n\n");

                    MessageController messageController = new MessageController();
                    var handler = update.Type switch
                    {
                        UpdateType.Message => messageController.HandleMessageAsync(botClient, update, cancellationToken),
                        //UpdateType.D=> messageController.EssentialAsyncMessage(botClient, update, cancellationToken),
                        _ => messageController.OtherMessage(botClient, update, cancellationToken),
                    };

                    await botClient.SendTextMessageAsync(
                        chatId: userId,
                        text: "Siz kanalga obuna bo'lgansiz. Bot ishga tushiriladi.",
                        cancellationToken: cancellationToken
                    );
                }
                else
                {
                    await botClient.SendTextMessageAsync(
                        chatId: userId,
                        text: "Siz kanalga obuna bo'lmagansiz. Iltimos, avval kanalga obuna bo'ling.",
                        replyMarkup: ButtonController.inlineKeyboard,
                        cancellationToken: cancellationToken
                    );
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public async Task<Task> HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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