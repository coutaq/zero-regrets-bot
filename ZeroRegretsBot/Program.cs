using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Awesome
{
    class Program
    {
        static ITelegramBotClient botClient;

        static void Main()
        {
            botClient = new TelegramBotClient("1127968745:AAGURMsF2N-4a-fuTbSUrtWbaOxxfaGol6I");
            var me = botClient.GetMeAsync().Result;
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message.Text);
            if (e.Message.Text == "шиз")
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
                await botClient.SendTextMessageAsync(e.Message.Chat, "тех");
            }
        }
    }
}