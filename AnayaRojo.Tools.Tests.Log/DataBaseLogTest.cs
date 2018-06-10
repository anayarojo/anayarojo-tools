using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnayaRojo.Tools.Tests.Log
{
    [TestClass]
    public class DataBaseLogTest
    {
        [TestMethod]
        public void SaveDataBaseLog()
        {
            // Act
            DataBaseLog.Save("Try save log.");
        }

        [TestMethod]
        public void SaveAllDataBaseLogs()
        {
            // Act
            DataBaseLog.Save(LogTypeEnum.SUCCESS, "Success log.");
            DataBaseLog.Save(LogTypeEnum.INFO, "Info log.");
            DataBaseLog.Save(LogTypeEnum.PROCESS, "Process log.");
            DataBaseLog.Save(LogTypeEnum.TRACKING, "Tracking log.");
            DataBaseLog.Save(LogTypeEnum.WARNING, "Warning log.");
            DataBaseLog.Save(LogTypeEnum.ERROR, "Error log.");
            DataBaseLog.Save(LogTypeEnum.EXCEPTION, "Exception log.");
        }
    }
}
