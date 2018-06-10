using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;
using AnayaRojo.Tools.Logs.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnayaRojo.Tools.Tests.LogException
{
    [TestClass]
    public class LogTest
    {
        [TestMethod]
        [ExpectedException(typeof(ConfigurationNotFoundException))]
        public void WriteLogException()
        {
            // Act
            Log.Write("Try write log.");
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationNotFoundException))]
        public void WriteAllLogsException()
        {
            // Act
            Log.Write(LogTypeEnum.SUCCESS, "Success log.");
            Log.Write(LogTypeEnum.INFO, "Info log.");
            Log.Write(LogTypeEnum.PROCESS, "Process log.");
            Log.Write(LogTypeEnum.TRACKING, "Tracking log.");
            Log.Write(LogTypeEnum.WARNING, "Warning log.");
            Log.Write(LogTypeEnum.ERROR, "Error log.");
            Log.Write(LogTypeEnum.EXCEPTION, "Exception log.");
        }
    }
}
