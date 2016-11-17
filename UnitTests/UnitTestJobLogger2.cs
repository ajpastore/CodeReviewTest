using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLogger.Devices;
using Moq;
using SimpleLogger;

namespace UnitTests
{
    [TestClass]
    public class UnitTestJobLogger2
    {
        [TestMethod]
        public void TestMethodLogOk()
        {
            Mock<IDeviceManager> mockDeviceManager = new Mock<IDeviceManager>();
            var deviceManager = mockDeviceManager.Object;

            var logger = new JobLogger2(deviceManager, AllowedMessageType.All);

            logger.Log("Hello", MessageType.Warning);

        }

        [TestMethod]
        public void TestMethodLogMessageOk()
        {
            Mock<IDeviceManager> mockDeviceManager = new Mock<IDeviceManager>();
            var deviceManager = mockDeviceManager.Object;

            var logger = new JobLogger2(deviceManager, AllowedMessageType.All);

            logger.LogMessage("Hello");

        }

        [TestMethod]
        public void TestMethodLogErrorOk()
        {
            Mock<IDeviceManager> mockDeviceManager = new Mock<IDeviceManager>();
            var deviceManager = mockDeviceManager.Object;

            var logger = new JobLogger2(deviceManager, AllowedMessageType.All);

            logger.LogError("Hello");
        }

        [TestMethod]
        public void TestMethodLogWarningOk()
        {
            Mock<IDeviceManager> mockDeviceManager = new Mock<IDeviceManager>();
            var deviceManager = mockDeviceManager.Object;

            var logger = new JobLogger2(deviceManager, AllowedMessageType.All);

            logger.LogWarning("Hello");

        }


        [TestMethod]
        [ExpectedException(typeof(System.Exception),"Invalid configuration, no message allowed to log.")]
        public void TestMethodLogNotOkException()
        {
            Mock<IDeviceManager> mockDeviceManager = new Mock<IDeviceManager>();
            var deviceManager = mockDeviceManager.Object;

            var logger = new JobLogger2(deviceManager, AllowedMessageType.None);

            logger.LogWarning("Hello");

        }

    }
}
