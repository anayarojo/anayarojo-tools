using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnayaRojo.Tools.Tests.Log
{
    [TestClass]
    public class EventLogTest
    {
        [TestMethod]
        public void SaveEventLog()
        {
            // Act
            EventLog.Save("Try save log.");
        }

        [TestMethod]
        public void SaveAllEventLogs()
        {
            // Act
            EventLog.Save(LogTypeEnum.SUCCESS, "Success log.");
            EventLog.Save(LogTypeEnum.INFO, "Info log.");
            EventLog.Save(LogTypeEnum.PROCESS, "Process log.");
            EventLog.Save(LogTypeEnum.TRACKING, "Tracking log.");
            EventLog.Save(LogTypeEnum.WARNING, "Warning log.");
            EventLog.Save(LogTypeEnum.ERROR, "Error log.");
            EventLog.Save(LogTypeEnum.EXCEPTION, "Exception log.");
        }
    }
}
