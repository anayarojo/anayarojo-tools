using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnayaRojo.Tools.Configs.Models
{
    /// <summary>
    ///     Modelo para guardar la configuración del log por correo electrónico.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 27/05/2018
    /// </remarks>
    public class MailLogModel
    {
        /// <summary>
        ///     Bandera que indica si el log se estara guardado en la base de datos.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        ///     Servidor de correo electrónico.
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        ///     Puerto del servidor de correo electrónico.
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        ///     Usuario del servidor de correo electrónico.
        /// </summary>
        public string User { get; set; }
        /// <summary>
        ///     Contraseña del usuario del servidor de correo electrónico.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        ///     Nombre del correo remitente.
        /// </summary>
        public string FromName { get; set; }
        /// <summary>
        ///     Correo remitente.
        /// </summary>
        public string FromMail { get; set; }
        /// <summary>
        ///     Nombre del correo destinatario.
        /// </summary>
        public string ToName { get; set; }
        /// <summary>
        ///     Correo destinatario.
        /// </summary>
        public string ToMail { get; set; }
        /// <summary>
        ///     Habilitar SSL
        /// </summary>
        public bool EnableSsl { get; set; }
    }
}
