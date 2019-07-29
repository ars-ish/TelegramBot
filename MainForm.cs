
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Args;
using Telegram.Bot;
using System.Net;
using Telegram.Bot.Types.ReplyMarkups;

namespace TestBot
{
	public partial class MainForm : Form
	{
		
		private static Telegram.Bot.TelegramBotClient Bot;
		
		public MainForm()
		{	
			InitializeComponent();

        }

		void Button1Click(object sender, EventArgs e)
		{
            WebProxy wp = new WebProxy("185.146.112.24:8080", true);
            //wp.Credentials = new NetworkCredential("user1", "user1Password");
            Bot = new TelegramBotClient("963348734:AAGb_uFqxSh0hi3ajgEYCWEelxwvU2nnlUE", wp);
            var me = Bot.GetMeAsync().Result;
            var message = MessageBox.Show(me.Username);
            Bot.OnMessage += MessageHandler;
			Bot.StartReceiving();
  			button1.Enabled = false;			
		}

        static void MessageHandler(object sender, MessageEventArgs messageEventArgs)
        {
            var markup = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton("Privet"),
                new KeyboardButton("Hello"),
                new KeyboardButton("Konechiva"),
            });
            markup.OneTimeKeyboard = true;
            var chatId = messageEventArgs.Message.Chat.Id;
            Bot.SendTextMessageAsync(chatId, "Hello world", replyMarkup: markup);
        }

    }
}
