using System;
using System.ComponentModel;
using System.Reflection;

namespace AnayaRojo.Tools.Extensions.Enums
{
    /// <summary>
    ///     Extensión para facilitar el trabajo con los enumeradores.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 18/12/2017
    /// </remarks>
    public static class EnumExtension
    {
        /// <summary>
        ///     Método para obtener la descripción de un enumerador.
        /// </summary>
        /// <param name="pObjElement">
        ///     Enumerador
        /// </param>
        /// <returns>
        ///     Descripción
        /// </returns>
        public static string GetDescription(this System.Enum pObjElement)
        {
            Type lObjType = pObjElement.GetType();
            MemberInfo[] lArrObjMemberInfo = lObjType.GetMember(pObjElement.ToString());
            if (lArrObjMemberInfo != null && lArrObjMemberInfo.Length > 0)
            {
                object[] lArrObjAtributes = lArrObjMemberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (lArrObjAtributes != null && lArrObjAtributes.Length > 0)
                {
                    return ((DescriptionAttribute)lArrObjAtributes[0]).Description;
                }
            }

            return pObjElement.ToString();
        }

        /// <summary>
        ///     Método para obtener el valor de un enumerador a partir de su descripción.
        /// </summary>
        /// <typeparam name="T">
        ///     Tipo de enumerador
        /// </typeparam>
        /// <param name="pStrDescription">
        ///     Descripción del enumerador
        /// </param>
        /// <returns>
        ///     Enumerador
        /// </returns>
        public static T GetValueFromDescription<T>(string pStrDescription)
        {
            var lObjType = typeof(T);
            if (!lObjType.IsEnum) throw new InvalidOperationException();

            foreach (var lObjField in lObjType.GetFields())
            {
                var lObjAttribute = Attribute.GetCustomAttribute(lObjField, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (lObjAttribute != null)
                {
                    if (lObjAttribute.Description == pStrDescription)
                        return (T)lObjField.GetValue(null);
                }
                else
                {
                    if (lObjField.Name == pStrDescription)
                        return (T)lObjField.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "Description");
        }
    }
}
