using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;
using AnayaRojo.Tools.Logs.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnayaRojo.Tools.Tests.LogException
{
    [TestClass]
    public class EventLogTest
    {
        [TestMethod]
        [ExpectedException(typeof(ConfigurationNotFoundException))]
        public void SaveEventLogException()
        {
            // Act
            EventLog.Save("Try save log.");
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationNotFoundException))]
        public void SaveAllEventLogsException()
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
