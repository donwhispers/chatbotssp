using System;
using System.Threading;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;


namespace Awesome {
  class Program {
    static ITelegramBotClient botClient;
      
    static List <string> Butin = new List<string>();
    static List <string> Strigalev = new List<string>();
    static List <string> Protchenko = new List<string>();
    static List <string> Memas = new List<string>();


    static void Main() {
      botClient = new TelegramBotClient("676101534:AAGQMTb_4eHW_VstJDnK60ps8hx6jsP9OD4");
      Butin.Add("Для тех, кто не говорит по-русски... *шёпотом* А здесь такие есть");
      Butin.Add("Так это, как это ваша фамилия?");
      Butin.Add("Ясно, понятно.");
      Butin.Add("Достаточно");
      Butin.Add("Один белый убил четырёх красных.");
      
      Strigalev.Add("Семантические связи, молодые люди.");
      Strigalev.Add("Я вам в тысячный раз повторяю, эпам вас обманывает.");
      Strigalev.Add("Есть правила игры и по ним нужно играть");
      
      Protchenko.Add("Я пришла сюда работать не ради денег.");
      Protchenko.Add("Ну чё, сдаём или по домам?");
      Protchenko.Add("Я вам покажу, как развернуть Докер-контейнер, когда-нибудь");
      Protchenko.Add("Пойдёте лабы Гончаревичу сдвать");
      
      Memas.Add("https://raw.githubusercontent.com/donwhispers/chatbotssp/master/mems/izGUdkA7itU.jpg");
      Memas.Add("https://raw.githubusercontent.com/donwhispers/chatbotssp/master/mems/K0a0QHM67nk.jpg");
      Memas.Add("https://raw.githubusercontent.com/donwhispers/chatbotssp/master/mems/cq0D4htFVOo.jpg");
      Memas.Add("https://raw.githubusercontent.com/donwhispers/chatbotssp/master/mems/dpESvZRLMIE.jpg");
      Memas.Add("https://raw.githubusercontent.com/donwhispers/chatbotssp/master/mems/fKEjfI5ajbE.jpg");
      Memas.Add("https://raw.githubusercontent.com/donwhispers/chatbotssp/master/mems/bOb-Ji8DALk.jpg");
      
      var me = botClient.GetMeAsync().Result;
      Console.WriteLine(
        $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
      );

      botClient.OnMessage += Bot_OnMessage;
      botClient.StartReceiving();
      Thread.Sleep(int.MaxValue);
    }

    static async void Bot_OnMessage(object sender, MessageEventArgs e) {
      switch (e.Message.Text)
      {
      case  "Протченко":
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id} :: {e.Message.Text}.");
        Random r = new Random();
        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:  Protchenko[r.Next(0,Protchenko.Count)]
        );
        break;
      }
      case "Батин":
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id} :: {e.Message.Text}.");
        Random r = new Random();
        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:  Butin[r.Next(0,Butin.Count)]
        );
        break;
      }
      case "Стригалёв":
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id} :: {e.Message.Text}.");
        Random r = new Random();
        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:  Strigalev[r.Next(0,Strigalev.Count)]
        );
        break;
      }
      case "/help":
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id} :: {e.Message.Text}.");
        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:   "Протченко, Батин, Стригалёв; БОНУС: мемас"
        );
        break;
      }
      case "/start":
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id} :: {e.Message.Text}.");
        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:   "Привет, я храню цитаты преподов с АСОИ, введи /help, чтобы узнать, доступных преподов. "
        );
        break;
      }
      case "мемас":
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id} :: {e.Message.Text}.");
        Random r = new Random();
    await botClient.SendPhotoAsync(
          chatId: e.Message.Chat,
          photo: Memas[r.Next(0,Memas.Count)]
      );
  break;
      }
       default:
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id} :: {e.Message.Text}.");
        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:   "Это вряд ли фамилия препода"
        );
        break;
      }
      }
    }
  }
}
