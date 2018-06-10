using AnayaRojo.Tools.Logs.Enums;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AnayaRojo.Tools.Logs
{
    /// <summary>
    ///     Herramienta para guardar logs en la base de datos.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 27/05/2018
    /// </remarks>
    public class DataBaseLog
    {
        /// <summary>
        ///     Guardar log.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje.
        /// </param>
        public static void Save(string pStrMessage)
        {
            SaveDataBaseLog(LogTypeEnum.INFO, pStrMessage);
        }

        /// <summary>
        ///     Guardar log.
        /// </summary>
        /// <param name="pEnmType">
        ///     Tipo del log.
        /// </param>
        /// <param name="pStrMessage">
        ///     Mensaje.
        /// </param>
        public static void Save(LogTypeEnum pEnmType, string pStrMessage)
        {
            SaveDataBaseLog(pEnmType, pStrMessage);
        }

        /// <summary>
        ///     Guardar log.
        /// </summary>
        /// <param name="pEnmType">
        ///     Tipo del log.
        /// </param>
        /// <param name="pStrFormat">
        ///     Formato.
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parametros.
        /// </param>
        public static void Save(LogTypeEnum pEnmType, string pStrFormat, params object[] pArrObjArgs)
        {
            SaveDataBaseLog(pEnmType, string.Format(pStrFormat, pArrObjArgs));
        }

        private static void SaveDataBaseLog(LogTypeEnum pEnmType, string pStrMessage)
        {
            if (Log.Configuration.DataBaseLog.Active)
            {
                SqlConnection lObjConnection = null;

                try
                {
                    using (lObjConnection = new SqlConnection(Log.Configuration.DataBaseLog.ConnectionString))
                    {
                        lObjConnection.Open();

                        SqlCommand lObjCommand = new SqlCommand()
                        {
                            Connection = lObjConnection,
                            CommandType = CommandType.Text,
                            CommandText = GetSqlInsert()
                        };
                        
                        lObjCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;
                        lObjCommand.Parameters.Add("@Type", SqlDbType.Int).Value = pEnmType;
                        lObjCommand.Parameters.Add("@Message", SqlDbType.VarChar).Value = pStrMessage;

                        lObjCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception lObjException)
                {
                    Log.Write(lObjException);
                }
                finally
                {
                    if(lObjConnection != null)
                    {
                        lObjConnection.Close();
                    }
                }
            }
        }

        private static string GetSqlInsert()
        {
            return string.Format
            (
                "INSERT INTO {0} ({1}, {2}, {3}) VALUES (@Date, @Type, @Message)",
                Log.Configuration.DataBaseLog.Table,
                Log.Configuration.DataBaseLog.DateField,
                Log.Configuration.DataBaseLog.TypeField,
                Log.Configuration.DataBaseLog.MessageField
            );
        }
    }
}
