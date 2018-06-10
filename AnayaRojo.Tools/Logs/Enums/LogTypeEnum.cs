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
        [DescriptionAttribute("Información")]
        INFO = 0,
        /// <summary>
        /// Éxito
        /// </summary>
        [DescriptionAttribute("Éxito")]
        SUCCESS = 1,
        /// <summary>
        /// Seguimiento
        /// </summary>
        [DescriptionAttribute("Seguimiento")]
        TRACKING = 2,
        /// <summary>
        /// Proceso
        /// </summary>
        [DescriptionAttribute("Proceso")]
        PROCESS = 3,
        /// <summary>
        /// Alerta
        /// </summary>
        [DescriptionAttribute("Alerta")]
        WARNING = 4,
        /// <summary>
        /// Error
        /// </summary>
        [DescriptionAttribute("Error")]
        ERROR = 5,
        /// <summary>
        /// Excepción
        /// </summary>
        [DescriptionAttribute("Excepción")]
        EXCEPTION = 6,
    }
}
