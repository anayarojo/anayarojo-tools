namespace AnayaRojo.Tools.Configs.Models
{
    /// <summary>
    ///     Modelo para guardar la configuración de los logs.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 27/05/2018
    /// </remarks>
    public class LogsConfigurationModel
    {
        /// <summary>
        ///     Configuración de la visibilidad del log.
        /// </summary>
        public VisibilityModel Visibility { get; set; }
        /// <summary>
        ///     Configuración del log.
        /// </summary>
        public LogModel Log { get; set; }
        /// <summary>
        ///     Configuración de la consola del log.
        /// </summary>
        public ConsoleLogModel ConsoleLog { get; set; } 
        /// <summary>
        ///     Configuración del log de eventos.
        /// </summary>
        public EventLogModel EventLog { get; set; }
        /// <summary>
        ///     Configuración del log en la base de datos.
        /// </summary>
        public DataBaseLogModel DataBaseLog { get; set; }
        /// <summary>
        ///     Configuración del log por correo electrónico.
        /// </summary>
        public MailLogModel MailLog { get; set; }
    }
}
