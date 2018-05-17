using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnayaRojo.Tools.Logs.Models
{
    public class LogVisibilityModel
    {
        public string Format { get; set; }
        public string DateFormat { get; set; }
        public bool ShowInfo { get; set; }
        public bool ShowSuccess { get; set; }
        public bool ShowTracking { get; set; }
        public bool ShowProcess { get; set; }
        public bool ShowWarning { get; set; }
        public bool ShowError { get; set; }
        public bool ShowException { get; set; }
    }
}
