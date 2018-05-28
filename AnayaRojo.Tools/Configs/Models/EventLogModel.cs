namespace AnayaRojo.Tools.Configs.Models
{
    /// <summary>
    ///     Modelo para guardar la configuración del log de eventos.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 27/05/2018
    /// </remarks>
    public class EventLogModel
    {
        /// <summary>
        ///     Bandera que indica si el log se estara guardado en la base de datos.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        ///     Nombre del log de eventos.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///     Id del evento del tipo información.
        /// </summary>
        public int InfoId { get; set; }
        /// <summary>
        ///     Id del evento del tipo éxito.
        /// </summary>
        public int SuccessId { get; set; }
        /// <summary>
        ///     Id del evento del tipo seguimiento.
        /// </summary>
        public int TrackingId { get; set; }
        /// <summary>
        ///     Id del evento del tipo de proceso.
        /// </summary>
        public int ProcessId { get; set; }
        /// <summary>
        ///     Id del evento del tipo de alerta.
        /// </summary>
        public int WarningId { get; set; }
        /// <summary>
        ///     Id del evento del tipo de error.
        /// </summary>
        public int ErrorId { get; set; }
        /// <summary>
        ///     Id del evento del tipo excepción.
        /// </summary>
        public int ExceptionId { get; set; }
    }
}
