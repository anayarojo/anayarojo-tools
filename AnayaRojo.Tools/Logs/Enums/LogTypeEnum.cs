using System.ComponentModel;

namespace AnayaRojo.Tools.Logs.Enums
{
    /// <summary>
    ///     Listado de tipos de log.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 13/12/2017
    /// </remarks>
    public enum LogTypeEnum : int
    {
        /// <summary>
        /// Información
        /// </summary>
        [DescriptionAttribute("INFO")]
        INFO = 0,
        /// <summary>
        /// Éxito
        /// </summary>
        [DescriptionAttribute("SUCCESS")]
        SUCCESS = 1,
        /// <summary>
        /// Seguimiento
        /// </summary>
        [DescriptionAttribute("TRACKING")]
        TRACKING = 2,
        /// <summary>
        /// Proceso
        /// </summary>
        [DescriptionAttribute("PROCESS")]
        PROCESS = 3,
        /// <summary>
        /// Alerta
        /// </summary>
        [DescriptionAttribute("WARNING")]
        WARNING = 4,
        /// <summary>
        /// Error
        /// </summary>
        [DescriptionAttribute("ERROR")]
        ERROR = 5,
        /// <summary>
        /// Excepción
        /// </summary>
        [DescriptionAttribute("EXCEPTION")]
        EXCEPTION = 6,
    }
}
