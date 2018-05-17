
namespace AnayaRojo.Tools.Logs.Models
{
    public class DataBaseLogModel
    {
        public bool Active { get; set; }
        public string ConnectionString { get; set; }
        public string Table { get; set; }
        public string DateField { get; set; }
        public string TypeField { get; set; }
        public string MessageField { get; set; }
    }
}
