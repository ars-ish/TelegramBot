using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    static class MyTelegramBot
    {
        private static string Token = "963348734:AAGb_uFqxSh0hi3ajgEYCWEelxwvU2nnlUE";
        static public TelegramBotClient MyBotClient;
        private static string[] FilmsArray = {
            "Начало", "Остров проклятых", "Бойцовский клуб", "Однажды в Америке",
        "Гран Торино", "Бесславные ублюдки", "Интерстеллар", "Отступники"};

        public static void InitializeMyBot()
        {
            WebProxy wp = new WebProxy("185.146.112.24:8080", true);
            MyBotClient = new TelegramBotClient(Token, wp);
            MyBotClient.OnMessage += MessageHandler;
            MyBotClient.StartReceiving();
        }

        static void MessageHandler(object sender, MessageEventArgs messageEventArgs)
        {
            string replyMessage = null;
            

            if (messageEventArgs.Message.Text.Trim(' ').ToLower() == "посоветуй фильм")
            {
                var rnd = new Random();
                replyMessage = FilmsArray[rnd.Next(FilmsArray.Length)];
            }

            if (messageEventArgs.Message.Text.Trim(' ').ToLower() == "/start")
            {
                replyMessage = "Привет!";

            }

            var markup = new ReplyKeyboardMarkup(new KeyboardButton("Посоветуй фильм"));
            markup.OneTimeKeyboard = false;
            
            var chatId = messageEventArgs.Message.Chat.Id;
            ((TelegramBotClient)sender).SendTextMessageAsync(chatId, replyMessage, replyMarkup: markup);
        }
    }
}
