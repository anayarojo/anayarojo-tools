using System;

namespace AnayaRojo.Tools.Extensions.Date
{
    /// <summary>
    ///     Extensión para facilitar el uso de fechas
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 09/01/2018
    /// </remarks>
    public static class DateTimeExtension
    {
        /// <summary>
        ///     Método para obtener una fecha en un día se la semana específico
        /// </summary>
        /// <param name="pObjDateTime">
        ///     Fecha
        /// </param>
        /// <param name="pObjStartOfWeek">
        ///     Dia de la semana
        /// </param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime pObjDateTime, DayOfWeek pObjStartOfWeek)
        {
            int lIntDiff = (7 + (pObjDateTime.DayOfWeek - pObjStartOfWeek)) % 7;
            return pObjDateTime.AddDays(-1 * lIntDiff).Date;
        }
    }
}
