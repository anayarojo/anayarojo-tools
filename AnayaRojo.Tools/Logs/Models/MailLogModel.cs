
namespace AnayaRojo.Tools.Logs.Models
{
    public class MailLogModel
    {
        public bool Active { get; set; }
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string FromName { get; set; }
        public string FromMail { get; set; }
        public string ToName { get; set; }
        public string ToMail { get; set; }
    }
}
