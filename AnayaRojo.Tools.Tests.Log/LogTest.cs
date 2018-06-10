using AnayaRojo.Tools.Logs.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnayaRojo.Tools.Tests.Log
{
    [TestClass]
    public class LogTest
    {
        [TestMethod]
        public void WriteLog()
        {
            // Act
            Logs.Log.Write("Try write log.");
        }

        [TestMethod]
        public void WriteAllLogs()
        {
            // Act
            Logs.Log.Write(LogTypeEnum.SUCCESS, "Success log.");
            Logs.Log.Write(LogTypeEnum.INFO, "Info log.");
            Logs.Log.Write(LogTypeEnum.PROCESS, "Process log.");
            Logs.Log.Write(LogTypeEnum.TRACKING, "Tracking log.");
            Logs.Log.Write(LogTypeEnum.WARNING, "Warning log.");
            Logs.Log.Write(LogTypeEnum.ERROR, "Error log.");
            Logs.Log.Write(LogTypeEnum.EXCEPTION, "Exception log.");
        }
    }
}
