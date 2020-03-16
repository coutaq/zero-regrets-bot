using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ZeroRegretsBot
{
    class Program
    {
        static ITelegramBotClient botClient;

        static void Main()
        {
            botClient = new TelegramBotClient(SecretFile.token);
            var me = botClient.GetMeAsync().Result;
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message.Text);
            try
            {
                if (e.Message.Voice.FileSize > 0)
                {
                    await botClient.SendTextMessageAsync(e.Message.Chat, "ой та ну тебя", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, e.Message.MessageId);
                }
                if (e.Message.Text.ToLower().Trim() == "шиз")
                {
                    Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
                    await botClient.SendTextMessageAsync(e.Message.Chat, "тех");
                }
            }
            catch { 
            }
        }
    }
}