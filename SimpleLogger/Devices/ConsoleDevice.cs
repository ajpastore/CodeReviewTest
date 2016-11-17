using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Devices
{
    internal class ConsoleDevice : IDevice
    {
     
        public void Log(string message, MessageType type)
        {
            switch(type)
            {
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case MessageType.Message:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            var toScreen = string.Format("{0} - {1} - {2}",
                 type.ToString(), DateTime.Now.ToShortDateString(), message);
            Console.WriteLine(toScreen);
        }
    }
}
