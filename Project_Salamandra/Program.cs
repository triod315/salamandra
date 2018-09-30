using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Telegram.Bot;

namespace Project_Salamandra
{
    class Program
    {
        static Bot salamandra_bot;
        static void Main(string[] args)
        {
            salamandra_bot = new Bot();

            salamandra_bot.Start();

            string command;
            while (true)
            { 
                command=Console.ReadLine();
                if (command == "stop") break;
            }
            salamandra_bot.Stop();
        }

        static void WorkingBot()
        {
            salamandra_bot.Start();
        }
         
    }
}
