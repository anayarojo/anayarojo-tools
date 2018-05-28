namespace AnayaRojo.Tools.Configs.Models
{
    /// <summary>
    ///     Modelo para guardar la configuración de la visibilidad del log.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 27/05/2018
    /// </remarks>
    public class VisibilityModel
    {
        /// <summary>
        ///     Bandera que indica si se mostraran los logs del tipo de información.
        /// </summary>
        public bool ShowInfo { get; set; }
        /// <summary>
        ///     Bandera que indica si se mostraran los logs del tipo éxito.
        /// </summary>
        public bool ShowSuccess { get; set; }
        /// <summary>
        ///     Bandera que indica si se mostraran los logs del tipo seguimiento.
        /// </summary>
        public bool ShowTracking { get; set; }
        /// <summary>
        ///     Bandera que indica si se mostraran los logs del tipo proceso.
        /// </summary>
        public bool ShowProcess { get; set; }
        /// <summary>
        ///     Bandera que indica si se mostraran los logs del tipo alerta.
        /// </summary>
        public bool ShowWarning { get; set; }
        /// <summary>
        ///     Bandera que indica si se mostraran los logs del tipo error.
        /// </summary>
        public bool ShowError { get; set; }
        /// <summary>
        ///     Bandera que indica si se mostraran los logs del tipo expceoción.
        /// </summary>
        public bool ShowException { get; set; }
    }
}
