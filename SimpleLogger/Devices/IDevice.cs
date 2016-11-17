using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Devices
{
    public interface IDevice
    {
        void Log(string message, MessageType type);
    }
}
