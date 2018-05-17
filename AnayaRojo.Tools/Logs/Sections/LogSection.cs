using AnayaRojo.Tools.Extensions.Object;
using AnayaRojo.Tools.Logs.Models;
using System.Configuration;
using System.Xml;


namespace AnayaRojo.Tools.Logs.Sections
{
    public class LogSection : IConfigurationSectionHandler
    {
        public object Create(object pObjParent, object pObjConfigContext, XmlNode pObjSection)
        {
            LogConfigurationModel lObjLogConfiguration = new LogConfigurationModel();

            lObjLogConfiguration.Visibility = pObjSection.SelectSingleNode("visibility") != null ? 
                GetVisibility(pObjSection.SelectSingleNode("visibility")) : GetDefaultVisibility();

            lObjLogConfiguration.ConsoleLog = pObjSection.SelectSingleNode("consoleLog") != null ? 
                GetConsoleLog(pObjSection.SelectSingleNode("consoleLog")) : GetDefaultConsoleLog();

            lObjLogConfiguration.DataBaseLog = pObjSection.SelectSingleNode("dataBaseLog") != null ?
                GetDataBaseLog(pObjSection.SelectSingleNode("dataBaseLog")) : GetDefaultDataBaseLog();

            lObjLogConfiguration.EventLog = pObjSection.SelectSingleNode("eventLog") != null ?
                GetEventLog(pObjSection.SelectSingleNode("eventLog")) : GetDefaultEventLog();

            lObjLogConfiguration.FileLog = pObjSection.SelectSingleNode("fileLog") != null ?
                GetFileLog(pObjSection.SelectSingleNode("fileLog")) : GetDefaultFileLog();

            return lObjLogConfiguration;
        }

        private LogVisibilityModel GetVisibility(XmlNode lObjNode)
        {
            return new LogVisibilityModel()
            {
                Format = lObjNode.Attributes["format"].Value.GetValue<string>(),
                DateFormat = lObjNode.Attributes["dateFormat"].Value.GetValue<string>(),
                ShowInfo = lObjNode.Attributes["showInfo"].Value.GetValue<bool>(),
                ShowSuccess = lObjNode.Attributes["showSuccess"].Value.GetValue<bool>(),
                ShowTracking = lObjNode.Attributes["showTracking"].Value.GetValue<bool>(),
                ShowProcess = lObjNode.Attributes["showProcess"].Value.GetValue<bool>(),
                ShowWarning = lObjNode.Attributes["showWarning"].Value.GetValue<bool>(),
                ShowError = lObjNode.Attributes["showError"].Value.GetValue<bool>(),
                ShowException = lObjNode.Attributes["showException"].Value.GetValue<bool>()
            };
        }

        private LogVisibilityModel GetDefaultVisibility()
        {
            return new LogVisibilityModel()
            {
                Format = "",
                ShowInfo = false,
                ShowTracking = false,
                ShowProcess = false,
                ShowWarning = false,
                ShowError = true,
                ShowException = true
            };
        }

        private ConsoleLogModel GetConsoleLog(XmlNode lObjNode)
        {
            return new ConsoleLogModel()
            {
                Active = lObjNode.Attributes["active"].Value.GetValue<bool>()
            };
        }

        private ConsoleLogModel GetDefaultConsoleLog()
        {
            return new ConsoleLogModel()
            {
                Active = false
            };
        }

        private DataBaseLogModel GetDataBaseLog(XmlNode lObjNode)
        {
            return new DataBaseLogModel()
            {
                Active = lObjNode.Attributes["active"].Value.GetValue<bool>(),
                ConnectionString = lObjNode.Attributes["connectionString"].Value.GetValue<string>(),
                Table = lObjNode.Attributes["table"].Value.GetValue<string>(),
                TypeField = lObjNode.Attributes["typeField"].Value.GetValue<string>(),
                MessageField = lObjNode.Attributes["messageField"].Value.GetValue<string>()
            };
        }

        private DataBaseLogModel GetDefaultDataBaseLog()
        {
            return new DataBaseLogModel()
            {
                Active = false
            };
        }

        private EventLogModel GetEventLog(XmlNode lObjNode)
        {
            return new EventLogModel()
            {
                Active = lObjNode.Attributes["active"].Value.GetValue<bool>(),
                Name = lObjNode.Attributes["name"].Value.GetValue<string>(),
                InfoId = lObjNode.Attributes["infoId"].Value.GetValue<int>(),
                SuccessId = lObjNode.Attributes["successId"].Value.GetValue<int>(),
                TrackingId = lObjNode.Attributes["trackingId"].Value.GetValue<int>(),
                ProcessId = lObjNode.Attributes["processId"].Value.GetValue<int>(),
                WarningId = lObjNode.Attributes["warningId"].Value.GetValue<int>(),
                ErrorId = lObjNode.Attributes["errorId"].Value.GetValue<int>(),
                ExceptionId = lObjNode.Attributes["exceptionId"].Value.GetValue<int>()
            };
        }

        private EventLogModel GetDefaultEventLog()
        {
            return new EventLogModel()
            {
                Active = false
            };
        }

        private FileLogModel GetFileLog(XmlNode lObjNode)
        {
            return new FileLogModel()
            {
                Active = lObjNode.Attributes["active"].Value.GetValue<bool>(),
                Name = lObjNode.Attributes["name"].Value.GetValue<string>(),
                Path = lObjNode.Attributes["path"].Value.GetValue<string>()
            };
        }

        private FileLogModel GetDefaultFileLog()
        {
            return new FileLogModel()
            {
                Active = false
            };
        }

        private MailLogModel GetMailLog(XmlNode lObjNode)
        {
            return new MailLogModel()
            {
                Active = lObjNode.Attributes["active"].Value.GetValue<bool>(),
                Server = lObjNode.Attributes["server"].Value.GetValue<string>(),
                User = lObjNode.Attributes["user"].Value.GetValue<string>(),
                Password = lObjNode.Attributes["password"].Value.GetValue<string>(),
                FromName = lObjNode.Attributes["fromName"].Value.GetValue<string>(),
                FromMail = lObjNode.Attributes["fromMail"].Value.GetValue<string>(),
                ToName = lObjNode.Attributes["toName"].Value.GetValue<string>(),
                ToMail = lObjNode.Attributes["toMail"].Value.GetValue<string>()
            };
        }

        private MailLogModel GetDefaultMailLog()
        {
            return new MailLogModel()
            {
                Active = false
            };
        }
    }
}
