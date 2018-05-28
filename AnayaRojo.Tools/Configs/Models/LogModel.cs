namespace AnayaRojo.Tools.Configs.Models
{
    /// <summary>
    ///     Modelo para guardar la configuración del log.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 27/05/2018
    /// </remarks>
    public class LogModel
    {
        /// <summary>
        ///     Bandera que indica si el log se estara guardado.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        ///     Bandera que indica si el log es web.
        /// </summary>
        public bool WebLog { get; set; }
        /// <summary>
        ///     Bandera que indica si el log se guardara completo.
        /// </summary>
        public bool FullLog { get; set; }
        /// <summary>
        ///     Bandera que indica si el log se guardara el multiples archivos.
        /// </summary>
        public bool MultiFiles { get; set; }
        /// <summary>
        ///     Formato de log.
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        ///     Formato de la fecha del log.
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        ///     Nombre del archivo del log.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        ///     Bandera que indica si el log usa ruta relativa para el archivo del log.
        /// </summary>
        public bool RelativePath { get; set; }
        /// <summary>
        ///     Ruta del arhivo de log.
        /// </summary>
        public string Path { get; set; }
    }
}
