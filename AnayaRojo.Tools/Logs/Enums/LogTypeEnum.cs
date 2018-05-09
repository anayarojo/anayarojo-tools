using System.ComponentModel;

namespace AnayaRojo.Tools.Logs.Enums
{
    public enum LogTypeEnum : int
    {
        [DescriptionAttribute("Información")]
        INFO = 0,
        [DescriptionAttribute("Exitoso")]
        SUCCESS = 1,
        [DescriptionAttribute("Seguimiento")]
        TRACKING = 2,
        [DescriptionAttribute("Operación")]
        PROCESS = 3,
        [DescriptionAttribute("Advertencia")]
        WARNING = 4,
        [DescriptionAttribute("Error")]
        ERROR = 5,
        [DescriptionAttribute("Excepción")]
        EXCEPTION = 6,
    }
}
