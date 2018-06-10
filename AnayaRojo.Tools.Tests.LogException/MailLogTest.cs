using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;
using AnayaRojo.Tools.Logs.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnayaRojo.Tools.Tests.LogException
{
    [TestClass]
    public class MailLogTest
    {
        [TestMethod]
        [ExpectedException(typeof(ConfigurationNotFoundException))]
        public void SendMailLogException()
        {
            // Act
            MailLog.Send("Try send log.");
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationNotFoundException))]
        public void SendAllMailLogsException()
        {
            // Act
            MailLog.Send(LogTypeEnum.SUCCESS, "Success log.");
            MailLog.Send(LogTypeEnum.INFO, "Info log.");
            MailLog.Send(LogTypeEnum.PROCESS, "Process log.");
            MailLog.Send(LogTypeEnum.TRACKING, "Tracking log.");
            MailLog.Send(LogTypeEnum.WARNING, "Warning log.");
            MailLog.Send(LogTypeEnum.ERROR, "Error log.");
            MailLog.Send(LogTypeEnum.EXCEPTION, "Exception log.");
        }
    }
}
