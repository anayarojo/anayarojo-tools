using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;
using AnayaRojo.Tools.Logs.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnayaRojo.Tools.Tests.LogException
{
    [TestClass]
    public class ConsoleLogTest
    {
        [TestMethod]
        [ExpectedException(typeof(ConfigurationNotFoundException))]
        public void ShowConsoleLogException()
        {
            // Act
            ConsoleLog.Show("Try show log.");
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationNotFoundException))]
        public void ShowAllConsoleLogsException()
        {
            // Act
            ConsoleLog.Show(LogTypeEnum.SUCCESS, "Success log.");
            ConsoleLog.Show(LogTypeEnum.INFO, "Info log.");
            ConsoleLog.Show(LogTypeEnum.PROCESS, "Process log.");
            ConsoleLog.Show(LogTypeEnum.TRACKING, "Tracking log.");
            ConsoleLog.Show(LogTypeEnum.WARNING, "Warning log.");
            ConsoleLog.Show(LogTypeEnum.ERROR, "Error log.");
            ConsoleLog.Show(LogTypeEnum.EXCEPTION, "Exception log.");
        }
    }
}
