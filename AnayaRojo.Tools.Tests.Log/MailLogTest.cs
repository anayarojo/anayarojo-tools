using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnayaRojo.Tools.Tests.Log
{
    [TestClass]
    public class MailLogTest
    {
        [TestMethod]
        public void SendMailLog()
        {
            // Act
            MailLog.Send("Try send log.");
        }

        [TestMethod]
        public void SendAllMailLogs()
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
