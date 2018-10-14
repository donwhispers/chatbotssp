using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Awesome {
  class Program {
    static ITelegramBotClient botClient;

    static void Main() {
      botClient = new TelegramBotClient("676101534:AAGQMTb_4eHW_VstJDnK60ps8hx6jsP9OD4");

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
      case  "/protchenko":
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:   "Я пришла сюда работать не ради денег"
        );
        break;
      }
      case "/butin":
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:   "Так это, как это ваша фамилия?"
        );
        break;
      }
      case "/strigalev":
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:   "Семантические связи, молодые люди, семантические связи"
        );
        break;
      }
      case "/help":
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:   "/protchenko, /butin, /strigalev"
        );
        break;
      }
      case "/start":
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
        await botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          text:   "Hello! I'm ASOI-Memes chat-bot, today is " + DateTime.Now.ToString()
        );
        break;
      }
      case "/mem":
      {
    await botClient.SendPhotoAsync(
          chatId: e.Message.Chat,
  photo: "https://github.com/donwhispers/chatbotssp/blob/add_img_mem/K0a0QHM67nk.jpg"
);
  break;
      }
       default:
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
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
