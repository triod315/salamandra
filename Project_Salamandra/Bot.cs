using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;


namespace Project_Salamandra
{
    class Bot
    {

        private TelegramBotClient botClient;

        private string ConsoleReadToken()
        {
            ConsoleWriter.WriteInputMesage("write token: ");
            string tmp = Console.ReadLine();
            ConsoleWriter.WritePosMessage("Taken token: " + tmp);
            return tmp;
        }

        private string token;
        public string Token
        {
            get => token;
        }

        /// <summary>
        /// Read token from console and create bot
        /// </summary>
        public Bot()
        {
            token = ConsoleReadToken();
            InitializeBot();
        }

        /// <summary>
        /// Get token as parameter and create bot
        /// </summary>
        /// <param name="token">Bot's token</param>
        public Bot(string token)
        {
            this.token = token;
            InitializeBot();
        }

        private void InitializeBot()
        {
            botClient = new TelegramBotClient(token);
            botClient.OnMessage += OnMessage;
            ConsoleWriter.WritePosMessage("Bot created successfully");
        }

        public void Start()
        {
            botClient.StartReceiving();
            ConsoleWriter.WritePosMessage("Bot is alive");
        }

        public void Stop()
        {
            botClient.StopReceiving();
            ConsoleWriter.WriteNegMessage("Bot is dead");
        }
        void OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {

            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                string message = e.Message.Text;
                ConsoleWriter.WriteUserMessage(e.Message.Chat.Id + "> " + e.Message.Text);
                if (message == "/time" || message.ToLower().Contains("time"))
                {
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, DateTime.Now.ToString());
                    ConsoleWriter.WriteBotMessage(DateTime.Now.ToString());
                }
                if (message == "request")
                {
                    botClient.SendTextMessageAsync(e.Message.Chat.Id, "response \n200");
                    ConsoleWriter.WriteBotMessage("response \n200");
                }
            }
            else
            {
                ConsoleWriter.WriteNegMessage("Undefined message");
                botClient.SendTextMessageAsync(e.Message.Chat.Id, "Sorry,but I can't understand you");
            }
        }

    }

    static class ConsoleWriter
    {
        static ConsoleColor clBefore;

        private static void WriteMessage(string message, ConsoleColor color)
        {
            clBefore = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message + "\n");
            Console.ForegroundColor = clBefore;
        }

        public static void WritePosMessage(string message) => WriteMessage(message, ConsoleColor.Green);

        public static void WriteNegMessage(string message) => WriteMessage(message, ConsoleColor.Red);

        public static void WriteBotMessage(string message) => Console.WriteLine("Bot > " + message);

        public static void WriteUserMessage(string message) => Console.WriteLine("User\\ " + message);

        public static void WriteInputMesage(string message) => WriteMessage(message, ConsoleColor.Blue);
    }
}
