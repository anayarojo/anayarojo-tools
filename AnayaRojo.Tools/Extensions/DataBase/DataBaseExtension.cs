using System;
using System.IO;

namespace AnayaRojo.Tools.Extensions.DataBase
{
    /// <summary>
    ///     Extensión para la las clases que controlen el acceso a datos.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 18/12/2017
    /// </remarks>
    public static class DataBaseExtension
    {
        /// <summary>
        ///     Método para obtener comandos sql.
        /// </summary>
        /// <param name="pObjCurrentObject">
        ///     Clase u objeto que controla del acceso a datos.
        /// </param>
        /// <param name="pStrNamespace">
        ///     Nombre de espacio del comando sql.
        /// </param>
        /// <param name="pStrResource">
        ///     Nombre del comando sql.
        /// </param>
        /// <returns>
        ///     Comando sql.
        /// </returns>
        public static string GetSQL(this object pObjCurrentObject, string pStrNamespace, string pStrResource)
        {
            Type lObjBaseType = (typeof(Type).IsAssignableFrom(pObjCurrentObject.GetType())) ? (Type)pObjCurrentObject : pObjCurrentObject.GetType();

            if (lObjBaseType.Assembly.IsDynamic)
                lObjBaseType = lObjBaseType.BaseType;

            using (var lObjStream = lObjBaseType.Assembly.GetManifestResourceStream(pStrNamespace + "." + pStrResource + ".sql"))
            {
                if (lObjStream != null)
                {
                    using (var lObjStreamReader = new StreamReader(lObjStream))
                    {
                        return lObjStreamReader.ReadToEnd();
                    }
                }
            }
            return string.Empty;
        }
    }
}
