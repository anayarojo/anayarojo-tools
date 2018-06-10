using AnayaRojo.Tools.Configs;
using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;
using System;

namespace AnayaRojo.Tools.Tests.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            // ## LOG

            //Default log
            Log.Write("Log test");

            //Write by type
            Log.Write(LogTypeEnum.SUCCESS, "Success log");
            Log.Write(LogTypeEnum.INFO, "Info log");
            Log.Write(LogTypeEnum.PROCESS, "Process log");
            Log.Write(LogTypeEnum.TRACKING, "Tracking log");
            Log.Write(LogTypeEnum.WARNING, "Warning log");
            Log.Write(LogTypeEnum.ERROR, "Error log");
            Log.Write(LogTypeEnum.EXCEPTION, "Exception log");

            //Write with format
            Log.Write(LogTypeEnum.INFO, "Format of the log {0}", "AnayaRojo");

            //Write exception
            Log.Write(new Exception("Log exception"));

            // ## CONSOLE LOG

            //Default log
            ConsoleLog.Show("Log test");

            //Show by type
            ConsoleLog.Show(LogTypeEnum.SUCCESS, "Success log");
            ConsoleLog.Show(LogTypeEnum.INFO, "Info log");
            ConsoleLog.Show(LogTypeEnum.PROCESS, "Process log");
            ConsoleLog.Show(LogTypeEnum.TRACKING, "Tracking log");
            ConsoleLog.Show(LogTypeEnum.WARNING, "Warning log");
            ConsoleLog.Show(LogTypeEnum.ERROR, "Error log");
            ConsoleLog.Show(LogTypeEnum.EXCEPTION, "Exception log");

            //Show with format
            ConsoleLog.Show(LogTypeEnum.INFO, "Format of the log {0}", "AnayaRojo");

            //Show exception
            ConsoleLog.Show(new Exception("Log exception"));

            // ## EVENT LOG

            //Default log
            EventLog.Save("Log test");

            //Save by type
            EventLog.Save(LogTypeEnum.SUCCESS, "Success log");
            EventLog.Save(LogTypeEnum.INFO, "Info log");
            EventLog.Save(LogTypeEnum.PROCESS, "Process log");
            EventLog.Save(LogTypeEnum.TRACKING, "Tracking log");
            EventLog.Save(LogTypeEnum.WARNING, "Warning log");
            EventLog.Save(LogTypeEnum.ERROR, "Error log");
            EventLog.Save(LogTypeEnum.EXCEPTION, "Exception log");

            //Save with format
            EventLog.Save(LogTypeEnum.INFO, "Format of the log {0}", "AnayaRojo");

            //Save exception
            EventLog.Save(new Exception("Log exception"));

            // ## DATA BASE LOG

            //Default log
            DataBaseLog.Save("Log test");

            //Save by type
            DataBaseLog.Save(LogTypeEnum.SUCCESS, "Success log");
            DataBaseLog.Save(LogTypeEnum.INFO, "Info log");
            DataBaseLog.Save(LogTypeEnum.PROCESS, "Process log");
            DataBaseLog.Save(LogTypeEnum.TRACKING, "Tracking log");
            DataBaseLog.Save(LogTypeEnum.WARNING, "Warning log");
            DataBaseLog.Save(LogTypeEnum.ERROR, "Error log");
            DataBaseLog.Save(LogTypeEnum.EXCEPTION, "Exception log");

            //Save with format
            DataBaseLog.Save(LogTypeEnum.INFO, "Format of the log {0}", "AnayaRojo");

            //Save exception
            DataBaseLog.Save(new Exception("Log exception"));

            // ## MAIL LOG

            //Default log
            MailLog.Send("Log test");

            //Send by type
            MailLog.Send(LogTypeEnum.SUCCESS, "Success log");
            MailLog.Send(LogTypeEnum.INFO, "Info log");
            MailLog.Send(LogTypeEnum.PROCESS, "Process log");
            MailLog.Send(LogTypeEnum.TRACKING, "Tracking log");
            MailLog.Send(LogTypeEnum.WARNING, "Warning log");
            MailLog.Send(LogTypeEnum.ERROR, "Error log");
            MailLog.Send(LogTypeEnum.EXCEPTION, "Exception log");

            //Send with format
            MailLog.Send(LogTypeEnum.INFO, "Format of the log {0}", "AnayaRojo");

            //Send exception
            MailLog.Send(new Exception("Log exception"));
        }
    }
}
