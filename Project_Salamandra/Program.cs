using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Project_Salamandra
{
    class Program
    { 
      
        static void Main(string[] args)
        {
            Bot salamandra_bot = new Bot("674075895:AAEmSJCp2YkSPP1w4j74wMQhSQI5wCD_krE");

            salamandra_bot.Start();
            Console.ReadLine();
            salamandra_bot.Stop();
        }

         
    }
}
