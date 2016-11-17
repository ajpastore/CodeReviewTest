using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReviewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = SimpleLogger.LogManager.GetLogger();

            logger.LogMessage("test de LogMessage");
            logger.LogWarning("test de LogWarning");
            logger.LogError("test de LogError");
            logger.Log("test de Log", SimpleLogger.MessageType.Message);
        }
    }
}
