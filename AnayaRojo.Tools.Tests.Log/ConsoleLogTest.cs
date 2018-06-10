using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnayaRojo.Tools.Tests.Log
{
    [TestClass]
    public class ConsoleLogTest
    {
        [TestMethod]
        public void ShowConsoleLog()
        {
            // Act
            ConsoleLog.Show("Try show log.");
        }

        [TestMethod]
        public void ShowAllConsoleLogs()
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
