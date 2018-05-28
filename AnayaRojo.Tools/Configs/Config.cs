using System;
using System.Configuration;
using System.Linq;

namespace AnayaRojo.Tools.Configs
{
    /// <summary>
    ///     Librería para acceder a la configuración de las aplicaciones en .Net
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 13/12/2017
    /// </remarks>
    public static class Config
    {
        /// <summary>
        ///     Método para obtener el valor de una configuración en un tipo de dato específico
        /// </summary>
        /// <exception cref="ConfigurationErrorsException">
        ///     Cuando no se encuentra la configuración.
        /// </exception>
        /// <typeparam name="T">
        ///     Tipo de dato genérico.
        /// </typeparam>
        /// <param name="pStrKey">
        ///     Llave de la configuración.
        /// </param>
        /// <returns>
        ///     Valor de la configuración
        /// </returns>
        public static T GetValue<T>(string pStrKey) where T : IConvertible
        {
            T lUknResultValue = default(T);

            if (ConfigurationManager.AppSettings.AllKeys.Contains(pStrKey))
            {
                string lStrTempValue = ConfigurationManager.AppSettings[pStrKey];

                if (typeof(T).IsEnum)
                {
                    lUknResultValue = (T)Enum.Parse(typeof(T), lStrTempValue, true);
                }
                else
                {
                    lUknResultValue = (T)Convert.ChangeType(lStrTempValue, typeof(T));
                }
            }
            else
            {
                throw new ConfigurationErrorsException(string.Format("{0} not found in app/webconfig.", pStrKey));
            }

            return lUknResultValue;
        }

        /// <summary>
        ///     Método para obtener la cadena de conexión.
        /// </summary>
        /// <param name="pStrConnectionName">
        ///     Nombre de la cadena de conexión
        /// </param>
        /// <returns>
        ///     Cadena de conexion
        /// </returns>
        public static string GetConnectionString(string pStrConnectionName)
        {
            return ConfigurationManager.ConnectionStrings[pStrConnectionName].ConnectionString;
        }
    }
}
