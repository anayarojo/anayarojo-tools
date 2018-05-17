using System.ComponentModel;

namespace AnayaRojo.Tools.Logs.Enums
{
    public enum LogTypeEnum : int
    {
        [DescriptionAttribute("INFO")]
        INFO = 0,
        [DescriptionAttribute("SUCCESS")]
        SUCCESS = 1,
        [DescriptionAttribute("TRACKING")]
        TRACKING = 2,
        [DescriptionAttribute("PROCESS")]
        PROCESS = 3,
        [DescriptionAttribute("WARNING")]
        WARNING = 4,
        [DescriptionAttribute("ERROR")]
        ERROR = 5,
        [DescriptionAttribute("EXCEPTION")]
        EXCEPTION = 6,
    }
}
