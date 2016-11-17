using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Devices
{
    internal class FileDevice : IDevice
    {
        public void Log(string message, MessageType type)
        {
            string fileContent = string.Empty;
            string filePath = string.Format("{0}{1}{2}{3}", 
                ConfigurationManager.AppSettings["LogFileDirectory"], 
                "LogFile", DateTime.Now.ToString("yyyyMMdd"), ".txt");

            if (File.Exists(filePath))
            {
                fileContent = File.ReadAllText(filePath);
            }


            fileContent += string.Format("{0} - {1} - {2} \r\n", 
                type.ToString(), DateTime.Now.ToShortDateString(), message);


            File.WriteAllText(filePath, fileContent);
        }
    }
}
