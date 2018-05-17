
namespace AnayaRojo.Tools.Logs.Models
{
    public class EventLogModel
    {
        public bool Active { get; set; }
        public string Name { get; set; }
        public int InfoId { get; set; }
        public int SuccessId { get; set; }
        public int TrackingId { get; set; }
        public int ProcessId { get; set; }
        public int WarningId { get; set; }
        public int ErrorId { get; set; }
        public int ExceptionId { get; set; }
    }
}
