﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace AnayaRojo.Tools.Extensions.Object
{
    /// <summary>
    ///     Extensión para facilitar el trabajo con objetos.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 18/12/2018
    /// </remarks>
    public static class ObjectExtension
    {
        /// <summary>
        ///     Método para copiar un objeto.
        /// </summary>
        /// <typeparam name="T">
        ///     Tipo de dato del objeto
        /// </typeparam>
        /// <param name="lObjSource">
        ///     Objeto a copiar
        /// </param>
        /// <returns>
        ///     Objeto copiado
        /// </returns>
        public static T Copy<T>(this T lObjSource)
        {
            T lObjCopy = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo lObjCopyProperty in lObjCopy.GetType().GetProperties())
            {
                lObjCopyProperty.SetValue
                (
                    lObjCopy,
                    lObjSource.GetType().GetProperties().Where(x => x.Name == lObjCopyProperty.Name).FirstOrDefault().GetValue(lObjSource)
                );
            }

            return lObjCopy;
        }

        /// <summary>
        ///     Método para copiar un objeto ignorado las propiedades virtuales, método ideal para evitar serializar referencias circulares y de gran volumen.
        /// </summary>
        /// <typeparam name="T">
        ///     Tipo de dato del objeto
        /// </typeparam>
        /// <param name="lObjSource">
        ///     Objeto a copiar
        /// </param>
        /// <returns>
        ///     Objeto copiado
        /// </returns>
        public static T CopyWithoutVirtualProperties<T>(this T lObjSource)
        {
            T lObjClone = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo lObjCloneProperty in lObjClone.GetType().GetProperties().Where(x => !x.GetMethod.IsVirtual))
            {
                lObjCloneProperty.SetValue
                (
                    lObjClone,
                    lObjSource.GetType().GetProperties().Where(x => x.Name == lObjCloneProperty.Name).FirstOrDefault().GetValue(lObjSource)
                );
            }

            return lObjClone;
        }

        /// <summary>
        ///     Método para obtener el valor de la propiedad de un objeto.
        /// </summary>
        /// <param name="pObjCurrentObject">
        ///     Objeto
        /// </param>
        /// <param name="pStrPropertyName">
        ///     Nombre de la propiedad
        /// </param>
        /// <returns>
        ///     Valor de la propiedad
        /// </returns>
        public static object GetPropertyValue(this object pObjCurrentObject, string pStrPropertyName)
        {
            return pObjCurrentObject.GetType().GetProperty(pStrPropertyName).GetValue(pObjCurrentObject, null);
        }

        /// <summary>
        ///     Método para obtener el valor de una propiedad de un objeto, propiedad distinguida por un atributo.
        /// </summary>
        /// <typeparam name="T">
        ///     Atributo
        /// </typeparam>
        /// <param name="pObjCurrentObject">
        ///     Objeto
        /// </param>
        /// <returns>
        ///     Valor de la propiedad
        /// </returns>
        public static object GetPropertyValueByAttribute<T>(this object pObjCurrentObject) where T : Attribute
        {
            return pObjCurrentObject.GetPropertyByAttribute<T>().GetValue(pObjCurrentObject, null);
        }

        /// <summary>
        ///     Método para obtener una propiedad de un objeto por un atributo.
        /// </summary>
        /// <typeparam name="T">
        ///     Atributo
        /// </typeparam>
        /// <param name="pObjCurrentObject">
        ///     Objeto
        /// </param>
        /// <returns>
        ///     Propiedad
        /// </returns>
        public static PropertyInfo GetPropertyByAttribute<T>(this object pObjCurrentObject) where T : Attribute
        {
            return pObjCurrentObject.GetType().GetProperties().Where(p => p.IsDefined(typeof(T), false)).FirstOrDefault();
        }

        /// <summary>
        ///     Método para convertir un objeto de un tipo de dato a otro.
        /// </summary>
        /// <typeparam name="T">
        ///     Tipo de dato actual
        /// </typeparam>
        /// <typeparam name="U">
        ///     Nuevo tipo de dato
        /// </typeparam>
        /// <param name="UnkObject">
        ///     Objeto con el tipo de dato actual
        /// </param>
        /// <returns>
        ///     Objeto con el nuevo tipo de dato
        /// </returns>
        public static U Parse<T, U>(this T UnkObject)
            where T : class
            where U : class
        {
            U lUnkResult = (U)Activator.CreateInstance(typeof(U));

            foreach (PropertyInfo lObjProperty in lUnkResult.GetType().GetProperties())
            {
                lObjProperty.SetValue(lUnkResult, Convert.ChangeType(UnkObject.GetType().GetProperties().FirstOrDefault(x => x.Name == lObjProperty.Name).GetValue(UnkObject), lObjProperty.PropertyType));
            }

            return lUnkResult;
        }

        /// <summary>
        ///     Métdo para convertir una lista de objetos de un tipo de dato a otro.
        /// </summary>
        /// <typeparam name="T">
        ///     Tipo de dato actual
        /// </typeparam>
        /// <typeparam name="U">
        ///     Nuevo tipo de dato
        /// </typeparam>
        /// <param name="pLstUnkObject">
        ///     Lista de objetos con el tipo de dato actual
        /// </param>
        /// <returns>
        ///     Lista de objetos con nuevo tipo de dato
        /// </returns>
        public static IList<U> ParseList<T, U>(this IList<T> pLstUnkObject)
            where T : class
            where U : class
        {
            IList<U> lLstUnkResult = new List<U>();

            foreach (T lUnkObject in pLstUnkObject)
            {
                lLstUnkResult.Add(lUnkObject.Parse<T, U>());
            }

            return lLstUnkResult;
        }

        /// <summary>
        ///     Convertir un objeto de un tipo a otro mediante el método de copíado de bits.
        /// </summary>
        /// <typeparam name="T">
        ///     Nuevo tipo de dato
        /// </typeparam>
        /// <param name="pUnkSource">
        ///     Objeto
        /// </param>
        /// <returns>
        ///     Objeto con nuevo tipo de dato
        /// </returns>
        public static T DeepConvert<T>(this object pUnkSource)
        {
            var IsNotSerializable = !typeof(T).IsSerializable;
            if (IsNotSerializable)
                throw new ArgumentException("The type must be serializable.", "source");

            var SourceIsNull = ReferenceEquals(pUnkSource, null);
            if (SourceIsNull)
                return default(T);

            var lObjFormatter = new BinaryFormatter();
            using (var lObjStream = new MemoryStream())
            {
                lObjFormatter.Serialize(lObjStream, pUnkSource);
                lObjStream.Seek(0, SeekOrigin.Begin);
                return (T)lObjFormatter.Deserialize(lObjStream);
            }
        }

        /// <summary>
        ///     Método para obtener un valor en un tipo de dato específico.
        /// </summary>
        /// <param name="pObjValue">
        ///     Valor para convertir.
        /// </param>
        /// <returns>
        ///     Valor en el tipo de dato especificado.
        /// </returns>
        public static T GetValue<T>(this object pObjValue) where T : IConvertible
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


        /// <summary>
        ///     Método para obtener contenido de archivos de texto incrustados en el codigo fuente.
        /// </summary>
        /// <param name="pObjCurrentObject">
        ///     Clase u objeto que controla el acceso a datos.
        /// </param>
        /// <param name="pStrResourcePath">
        ///     Ruta del recurso del archivo de texto.
        /// </param>
        /// <returns>
        ///     Contenido del archivo de texto.
        /// </returns>
        public static string GetTextFromResource(this object pObjCurrentObject, string pStrResourcePath)
        {
            Type lObjBaseType = (typeof(Type).IsAssignableFrom(pObjCurrentObject.GetType())) ? (Type)pObjCurrentObject : pObjCurrentObject.GetType();

            if (lObjBaseType.Assembly.IsDynamic)
                lObjBaseType = lObjBaseType.BaseType;

            using (var lObjStream = lObjBaseType.Assembly.GetManifestResourceStream(pStrResourcePath))
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

        /// <summary>
        ///     Método para obtener contenido de archivos de texto incrustados en el codigo fuente.
        /// </summary>
        /// <param name="pStrResourcePath">
        ///     Ruta del recurso del archivo de texto.
        /// </param>
        /// <returns>
        ///     Contenido del archivo de texto.
        /// </returns>
        public static string GetTextFromResource<T>(string pStrResourcePath) where T : class
        {
            T lObjCreateInstance = (T)Activator.CreateInstance(typeof(T));
            Type lObjBaseType = lObjCreateInstance.GetType();

            if (lObjBaseType.Assembly.IsDynamic)
                lObjBaseType = lObjBaseType.BaseType;

            using (var lObjStream = lObjBaseType.Assembly.GetManifestResourceStream(pStrResourcePath))
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

        /// <summary>
        ///     Método para obtener el stream de archivos de incrustados en el codigo fuente.
        /// </summary>
        /// <param name="pObjCurrentObject">
        ///     Clase u objeto que controla el acceso a datos.
        /// </param>
        /// <param name="pStrResourcePath">
        ///     Ruta del recurso del archivo de texto.
        /// </param>
        /// <returns>
        ///     Stream del archivo.
        /// </returns>
        public static Stream GetStreamFromResource(this object pObjCurrentObject, string pStrResourcePath)
        {
            Type lObjBaseType = (typeof(Type).IsAssignableFrom(pObjCurrentObject.GetType())) ? (Type)pObjCurrentObject : pObjCurrentObject.GetType();

            if (lObjBaseType.Assembly.IsDynamic)
                lObjBaseType = lObjBaseType.BaseType;

            return lObjBaseType.Assembly.GetManifestResourceStream(pStrResourcePath);
        }

        /// <summary>
        ///     Método para obtener el stream de archivos de incrustados en el codigo fuente.
        /// </summary>
        /// <param name="pStrResourcePath">
        ///     Ruta del recurso del archivo de texto.
        /// </param>
        /// <returns>
        ///     Stream del archivo.
        /// </returns>
        public static Stream GetStreamFromResource<T>(string pStrResourcePath) where T : class
        {
            T lObjCreateInstance = (T)Activator.CreateInstance(typeof(T));
            Type lObjBaseType = lObjCreateInstance.GetType();

            if (lObjBaseType.Assembly.IsDynamic)
                lObjBaseType = lObjBaseType.BaseType;

            return lObjBaseType.Assembly.GetManifestResourceStream(pStrResourcePath);
        }
    }
}
