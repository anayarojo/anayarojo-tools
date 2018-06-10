using AnayaRojo.Tools.Logs;

namespace AnayaRojo.Tools.Tests.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Write("Log Test");
            ConsoleLog.Show("Console Log Test");
            EventLog.Save("Event Log Test");
            DataBaseLog.Save("Data Base Log Test");
            MailLog.Send("Mail Log Test");
        }
    }
}
