using System;
using System.Data.SqlClient;

namespace AnayaRojo.Tools.Extensions.DataBase
{
    /// <summary>
    ///     Extensión para obtener y convertir los datos desde un SqlDataReader.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 04/05/2018
    /// </remarks>
    public static class SqlDataReaderExtension
    {
        /// <summary>
        ///     Método para obtener un valor en un tipo de dato específico desde un SqlDataReader.
        /// </summary>
        /// <param name="pObjDataReader">
        ///     Data Reader.
        /// </param>
        /// <param name="pStrField">
        ///    Nombre del campo.
        /// </param>
        /// <returns>
        ///     Valor en el tipo de dato especificado.
        /// </returns>
        public static T Get<T>(this SqlDataReader pObjDataReader, string pStrField) where T : IConvertible
        {
            return GetValue<T>(pObjDataReader[pStrField]);
        }

        /// <summary>
        ///     Método para obtener un valor en un tipo de dato específico desde un SqlDataReader.
        /// </summary>
        /// <param name="pObjDataReader">
        ///     Data Reader.
        /// </param>
        /// <param name="pIntIndex">
        ///    índice del campo.
        /// </param>
        /// <returns>
        ///     Valor en el tipo de dato especificado.
        /// </returns>
        public static T Get<T>(this SqlDataReader pObjDataReader, int pIntIndex) where T : IConvertible
        {
            return GetValue<T>(pObjDataReader[pIntIndex]);
        }

        private static T GetValue<T>(object pObjValue) where T : IConvertible
        {
            T lUknResultValue = default(T);
            var lUnkTempValue = pObjValue.ToString();

            if (typeof(T).IsEnum)
            {
                lUknResultValue = (T)Enum.Parse(typeof(T), lUnkTempValue, true);
            }
            else
            {
                lUknResultValue = (T)Convert.ChangeType(lUnkTempValue, typeof(T));
            }

            return lUknResultValue;
        }
    }
}
