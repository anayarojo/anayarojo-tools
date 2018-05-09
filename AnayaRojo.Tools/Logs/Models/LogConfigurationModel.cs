
namespace AnayaRojo.Tools.Logs.Models
{
    public class LogConfigurationModel
    {
        public LogVisibilityModel Visibility { get; set; }
        public ConsoleLogModel ConsoleLog { get; set; }
        public DataBaseLogModel DataBaseLog { get; set; }
        public EventLogModel EventLog { get; set; }
        public FileLogModel FileLog { get; set; }
        public MailLogModel MailLog { get; set; }
    }
}
