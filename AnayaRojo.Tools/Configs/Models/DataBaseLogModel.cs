namespace AnayaRojo.Tools.Configs.Models
{
    /// <summary>
    ///     Modelo para guardar la configuración del log de base de datos.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 27/05/2018
    /// </remarks>
    public class DataBaseLogModel
    {
        /// <summary>
        ///     Bandera que indica si el log se estara guardado en la base de datos.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        ///     Cadena de conexión de la base de datos de donde se estara guardando el log.
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        ///     Tabla de la base de datos de donde se estara guardando el log.
        /// </summary>
        public string Table { get; set; }
        /// <summary>
        ///     Campo donde se guardara la fecha del log.
        /// </summary>
        public string DateField { get; set; }
        /// <summary>
        ///     Campo donde se guardara el tipo del log.
        /// </summary>
        public string TypeField { get; set; }
        /// <summary>
        ///     Campo donde se guardara el mensaje del log.
        /// </summary>
        public string MessageField { get; set; }
    }
}
