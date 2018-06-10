using AnayaRojo.Tools.Logs.Enums;
using System;
using System.Diagnostics;

namespace AnayaRojo.Tools.Logs
{
    /// <summary>
    ///     Herramienta para guardar logs en los eventos de Windows.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 27/05/2018
    /// </remarks>
    public class EventLog
    {
        /// <summary>
        ///     Mostrar log.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje.
        /// </param>
        public static void Save(string pStrMessage)
        {
            SaveEventLog(LogTypeEnum.INFO, pStrMessage);
        }

        /// <summary>
        ///     Mostrar log.
        /// </summary>
        /// <param name="pEnmType">
        ///     Tipo del log.
        /// </param>
        /// <param name="pStrMessage">
        ///     Mensaje.
        /// </param>
        public static void Save(LogTypeEnum pEnmType, string pStrMessage)
        {
            SaveEventLog(pEnmType, pStrMessage);
        }

        /// <summary>
        ///     Mostrar log.
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
            SaveEventLog(pEnmType, string.Format(pStrFormat, pArrObjArgs));
        }

        private static void SaveEventLog(LogTypeEnum pEnmType, string pStrMessage)
        {
            string lStrEventLogName = "";
            if (Log.Configuration.EventLog.Active)
            {
                try
                {
                    System.Diagnostics.EventLog lObjEventLog = new System.Diagnostics.EventLog();
                    lStrEventLogName = !string.IsNullOrEmpty(Log.Configuration.EventLog.Name)? 
                                                             Log.Configuration.EventLog.Name :
                                                             Process.GetCurrentProcess().ProcessName;

                    if (!System.Diagnostics.EventLog.SourceExists(lStrEventLogName))
                    {
                        System.Diagnostics.EventLog.CreateEventSource(lStrEventLogName, "Application");
                    }

                    lObjEventLog.Source = lStrEventLogName;
                    lObjEventLog.WriteEntry(pStrMessage, GetEntryType(pEnmType), GetEntryId(pEnmType));
                    lObjEventLog.Close();
                }
                catch (Exception lObjException)
                {
                    Log.Write(lObjException);
                }
            }
        }

        private static int GetEntryId(LogTypeEnum pEnmType)
        {
            switch (pEnmType)
            {
                case LogTypeEnum.SUCCESS:
                    return Log.Configuration.EventLog.SuccessId;
                case LogTypeEnum.WARNING:
                    return Log.Configuration.EventLog.WarningId;
                case LogTypeEnum.ERROR:
                    return Log.Configuration.EventLog.ErrorId;
                case LogTypeEnum.EXCEPTION:
                    return Log.Configuration.EventLog.ExceptionId;
                case LogTypeEnum.TRACKING:
                    return Log.Configuration.EventLog.TrackingId;
                case LogTypeEnum.PROCESS:
                    return Log.Configuration.EventLog.ProcessId;
                case LogTypeEnum.INFO:
                    return Log.Configuration.EventLog.InfoId;
                default:
                    return Log.Configuration.EventLog.InfoId;
            }
        }

        private static EventLogEntryType GetEntryType(LogTypeEnum pEnmType)
        {
            switch (pEnmType)
            {
                case LogTypeEnum.SUCCESS:
                    return EventLogEntryType.Information;
                case LogTypeEnum.WARNING:
                    return EventLogEntryType.Warning;
                case LogTypeEnum.ERROR:
                    return EventLogEntryType.Error;
                case LogTypeEnum.EXCEPTION:
                    return EventLogEntryType.Error;
                case LogTypeEnum.TRACKING:
                    return EventLogEntryType.Information;
                case LogTypeEnum.PROCESS:
                    return EventLogEntryType.Information;
                case LogTypeEnum.INFO:
                    return EventLogEntryType.Information;
                default:
                    return EventLogEntryType.Information;
            }
        }
    }
}
