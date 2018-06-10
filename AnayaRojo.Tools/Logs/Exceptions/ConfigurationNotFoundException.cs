using System;
using System.Runtime.Serialization;

namespace AnayaRojo.Tools.Logs.Exceptions
{
    /// <summary> 
    ///     Excepción para señalar error al obtener una configuración.
    /// </summary>
    /// <remarks> 
    ///     Raul Anaya, 04/05/2017. 
    /// </remarks>
    [Serializable]
    public class ConfigurationNotFoundException : Exception
    {
        /// <summary>
        ///     Default constructor. 
        /// </summary>
        /// <remarks> 
        ///     Raul Anaya, 04/05/2017. 
        /// </remarks>
        public ConfigurationNotFoundException()
        {
        }

        /// <summary> 
        ///     Specialised constructor for use only by derived class. 
        /// </summary>
        /// <remarks> 
        ///     Raul Anaya, 04/05/2017. 
        /// </remarks>
        /// <param name="pStrMessage"> 
        ///     The exception message. 
        /// </param>
        /// <returns> 
        ///     A Tuple. 
        /// </returns>
        public ConfigurationNotFoundException(string pStrMessage)
            : base(pStrMessage)
        {
        }

        /// <summary> 
        ///     Specialised constructor for use only by derived class. 
        /// </summary>
        /// <remarks> 
        ///     Raul Anaya, 04/05/2017. 
        /// </remarks>
        /// <param name="pStrMessage"> 
        ///     The exception message. 
        /// </param>
        /// <param name="pObjException"> 
        ///     The exception object. 
        /// </param>
        /// <returns> 
        ///     A Tuple. 
        /// </returns>
        public ConfigurationNotFoundException(string pStrMessage, Exception pObjException)
            : base(pStrMessage, pObjException)
        {
        }

        /// <summary> 
        ///     Specialised constructor for use only by derived class. 
        /// </summary>
        /// <remarks> 
        ///     Raul Anaya, 04/05/2017. 
        /// </remarks>
        /// <param name="pObjSerializationInfo"> 
        ///     Information describing the object serialization. 
        /// </param>
        /// <param name="pObjContext">           
        ///     Context for the object. 
        /// </param>
        protected ConfigurationNotFoundException(SerializationInfo pObjSerializationInfo, StreamingContext pObjContext)
        {
        }
    }
}

