using AnayaRojo.Tools.Configs.Models;
using AnayaRojo.Tools.Extensions.Object;
using System.Configuration;
using System.Xml;

namespace AnayaRojo.Tools.Configs.Sections
{
    /// <summary>
    ///     Sección de la configuración de los logs.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 27/05/2018
    /// </remarks>
    public class LogsSection : IConfigurationSectionHandler
    {
        /// <summary>
        ///     Crear modelo de la configuración de los logs.
        /// </summary>
        /// <param name="pObjParent">
        ///     Padre
        /// </param>
        /// <param name="pObjConfigContext">
        ///     Contexto
        /// </param>
        /// <param name="pObjSection">
        ///     Sección
        /// </param>
        /// <returns>
        ///     Modelo de la configuración de los logs.
        /// </returns>
        public object Create(object pObjParent, object pObjConfigContext, XmlNode pObjSection)
        {
            LogsConfigurationModel lObjLogConfiguration = new LogsConfigurationModel();

            lObjLogConfiguration.Visibility = pObjSection.SelectSingleNode("visibility") != null ?
                GetVisibility(pObjSection.SelectSingleNode("visibility")) : GetDefaultVisibility();

            lObjLogConfiguration.Log = pObjSection.SelectSingleNode("log") != null ?
                GetLog(pObjSection.SelectSingleNode("log")) : GetDefaultFileLog();

            lObjLogConfiguration.ConsoleLog = pObjSection.SelectSingleNode("consoleLog") != null ?
                GetConsoleLog(pObjSection.SelectSingleNode("consoleLog")) : GetDefaultConsoleLog();

            lObjLogConfiguration.EventLog = pObjSection.SelectSingleNode("eventLog") != null ?
                GetEventLog(pObjSection.SelectSingleNode("eventLog")) : GetDefaultEventLog();

            lObjLogConfiguration.DataBaseLog = pObjSection.SelectSingleNode("dataBaseLog") != null ?
                GetDataBaseLog(pObjSection.SelectSingleNode("dataBaseLog")) : GetDefaultDataBaseLog();

            lObjLogConfiguration.MailLog = pObjSection.SelectSingleNode("mailLog") != null ?
                GetMailLog(pObjSection.SelectSingleNode("mailLog")) : GetDefaultMailLog();
            
            return lObjLogConfiguration;
        }

        private VisibilityModel GetVisibility(XmlNode lObjNode)
        {
            return new VisibilityModel()
            {
                ShowInfo = lObjNode.Attributes["showInfo"].Value.GetValue<bool>(),
                ShowSuccess = lObjNode.Attributes["showSuccess"].Value.GetValue<bool>(),
                ShowTracking = lObjNode.Attributes["showTracking"].Value.GetValue<bool>(),
                ShowProcess = lObjNode.Attributes["showProcess"].Value.GetValue<bool>(),
                ShowWarning = lObjNode.Attributes["showWarning"].Value.GetValue<bool>(),
                ShowError = lObjNode.Attributes["showError"].Value.GetValue<bool>(),
                ShowException = lObjNode.Attributes["showException"].Value.GetValue<bool>()
            };
        }

        private VisibilityModel GetDefaultVisibility()
        {
            return new VisibilityModel()
            {
                ShowInfo = false,
                ShowTracking = false,
                ShowProcess = false,
                ShowWarning = false,
                ShowError = true,
                ShowException = true
            };
        }

        private LogModel GetLog(XmlNode lObjNode)
        {
            return new LogModel()
            {
                Active = lObjNode.Attributes["active"].Value.GetValue<bool>(),
                WebLog = lObjNode.Attributes["webLog"].Value.GetValue<bool>(),
                FullLog = lObjNode.Attributes["fullLog"].Value.GetValue<bool>(),
                MultiFiles = lObjNode.Attributes["multiFiles"].Value.GetValue<bool>(),
                Format = lObjNode.Attributes["format"].Value.GetValue<string>(),
                DateFormat = lObjNode.Attributes["dateFormat"].Value.GetValue<string>(),
                FileName = lObjNode.Attributes["fileName"].Value.GetValue<string>(),
                RelativePath = lObjNode.Attributes["relativePath"].Value.GetValue<bool>(),
                Path = lObjNode.Attributes["path"].Value.GetValue<string>()
            };
        }

        private LogModel GetDefaultFileLog()
        {
            return new LogModel()
            {
                Active = false,
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
                DateField = lObjNode.Attributes["dateField"].Value.GetValue<string>(),
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
        
        private MailLogModel GetMailLog(XmlNode lObjNode)
        {
            return new MailLogModel()
            {
                Active = lObjNode.Attributes["active"].Value.GetValue<bool>(),
                Server = lObjNode.Attributes["server"].Value.GetValue<string>(),
                Port = lObjNode.Attributes["port"].Value.GetValue<int>(),
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
