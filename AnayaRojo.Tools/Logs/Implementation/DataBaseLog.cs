using AnayaRojo.Tools.Configuration;
using AnayaRojo.Tools.Logs.Enums;
using AnayaRojo.Tools.Logs.Interface;
using AnayaRojo.Tools.Extensions.Enums;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AnayaRojo.Tools.Logs.Implementation
{
    public class DataBaseLog : BaseLog, IBaseLog
    {
        public void WriteLog(string pStrMessage)
        {
            SaveLog(LogTypeEnum.INFO, pStrMessage);
        }

        public void WriteLog(LogTypeEnum pEnmType, string pStrMessage)
        {
            SaveLog(pEnmType, pStrMessage);
        }

        public void WriteLog(LogTypeEnum pEnmType, bool pBolIsSubLog, string pStrSubLogName, string pStrMessage)
        {
            SaveLog(pEnmType, pBolIsSubLog ? string.Format("{0} ─ {1}", pStrSubLogName, pStrMessage) : pStrMessage);
        }

        public void WriteLog(LogTypeEnum pEnmType, string pStrFormat, params object[] pArrObjArgs)
        {
            SaveLog(pEnmType, string.Format(pStrFormat, pArrObjArgs));
        }

        public void WriteLog(LogTypeEnum pEnmType, bool pBolIsSubLog, string pStrSubLogName, string pStrFormat, params object[] pArrObjArgs)
        {
            SaveLog(pEnmType, pBolIsSubLog ? string.Format("{0} ─ {1}", pStrSubLogName, string.Format(pStrFormat, pArrObjArgs)) : string.Format(pStrFormat, pArrObjArgs));
        }

        protected void SaveLog(LogTypeEnum pEnmType, string pStrMessage)
        {
            SqlConnection lObjConnection = null;

            if(Configuration.DataBaseLog.Active)
            {
                try
                {
                    using (lObjConnection = this.GetSqlConnection())
                    {
                        //Open
                        lObjConnection.Open();

                        //Command
                        SqlCommand lObjCommand = new SqlCommand
                        (
                            string.Format
                            (
                                "INSERT INTO {0} ({1}, {2}, {3}) VALUES (GETDATE(), @Type, @Message)",
                                Configuration.DataBaseLog.DateField,
                                Configuration.DataBaseLog.TypeField,
                                Configuration.DataBaseLog.MessageField
                            ),
                            lObjConnection
                        );

                        //Parameters
                        lObjCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = pEnmType.GetDescription();
                        lObjCommand.Parameters.Add("@Message", SqlDbType.VarChar).Value = pStrMessage;

                        //Execute
                        lObjCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception lObjException)
                {
                    //QsLog.WriteException(lObjException);
                }
                finally
                {
                    lObjConnection.Close();
                }
            }
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(this.Configuration.DataBaseLog.ConnectionString);
        }
    }
}
