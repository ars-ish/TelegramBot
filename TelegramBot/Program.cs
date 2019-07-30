using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Args;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using System.Net;
using System.Threading;

namespace TelegramBot
{
    class Program
    {
        public static ManualResetEvent waitHandle = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            MyTelegramBot.InitializeMyBot();
            var me = MyTelegramBot.MyBotClient.GetMeAsync().Result;
            Console.WriteLine(me);

            waitHandle.WaitOne();
        }
    }
}
