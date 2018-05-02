using System;
using System.Data.SqlClient;

namespace AnayaRojo.Tools.Extensions.DataBase
{
    public static class SqlDataReaderExtension
    {
        public static T Get<T>(this SqlDataReader pObjRecordset, string pStrField) where T : IConvertible
        {
            return GetValue<T>(pObjRecordset[pStrField]);
        }

        public static T Get<T>(this SqlDataReader pObjRecordset, int pIntIndex) where T : IConvertible
        {
            return GetValue<T>(pObjRecordset[pIntIndex]);
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
