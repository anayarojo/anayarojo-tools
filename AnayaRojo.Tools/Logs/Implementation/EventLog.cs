using AnayaRojo.Tools.Logs.Enums;
using AnayaRojo.Tools.Logs.Interface;
using System;
using System.Diagnostics;

namespace AnayaRojo.Tools.Logs.Implementation
{
    public class EventLog : BaseLog, IBaseLog
    {
        public void WriteLog(string pStrMessage)
        {
            SaveEventLog(pStrMessage, GetEntryType(LogTypeEnum.INFO), GetEntryId(LogTypeEnum.INFO));
        }

        public void WriteLog(LogTypeEnum pEnmType, string pStrMessage)
        {
            SaveEventLog(pStrMessage, GetEntryType(pEnmType), GetEntryId(pEnmType));
        }

        public void WriteLog(LogTypeEnum pEnmType, bool pBolIsSubLog, string pStrSubLogName, string pStrMessage)
        {
            SaveEventLog(pBolIsSubLog ? string.Format("{0} ─ {1}", pStrSubLogName, pStrMessage) : pStrMessage, GetEntryType(pEnmType), GetEntryId(pEnmType));
        }

        public void WriteLog(LogTypeEnum pEnmType, string pStrFormat, params object[] pArrObjArgs)
        {
            SaveEventLog(string.Format(pStrFormat, pArrObjArgs), GetEntryType(pEnmType), GetEntryId(pEnmType));
        }

        public void WriteLog(LogTypeEnum pEnmType, bool pBolIsSubLog, string pStrSubLogName, string pStrFormat, params object[] pArrObjArgs)
        {
            SaveEventLog(pBolIsSubLog ? string.Format("{0} ─ {1}", pStrSubLogName, string.Format(pStrFormat, pArrObjArgs)) : string.Format(pStrFormat, pArrObjArgs), GetEntryType(pEnmType), GetEntryId(pEnmType));
        }

        protected void SaveEventLog(string pStrMessage, EventLogEntryType pEnmType, int pIntId)
        {
            try
            {
                System.Diagnostics.EventLog lObjEventLog = new System.Diagnostics.EventLog();
                string lStrCurrentProcessName = Process.GetCurrentProcess().ProcessName;

                if (!System.Diagnostics.EventLog.SourceExists(lStrCurrentProcessName))
                {
                    System.Diagnostics.EventLog.CreateEventSource(lStrCurrentProcessName, "Application");
                }

                lObjEventLog.Source = lStrCurrentProcessName;
                lObjEventLog.WriteEntry(pStrMessage, pEnmType, pIntId);
                lObjEventLog.Close();
            }
            catch (Exception lObjException)
            {

            }
        }

        private int GetEntryId(LogTypeEnum pEnmType)
        {
            switch (pEnmType)
            {
                case LogTypeEnum.SUCCESS:
                    return Configuration.EventLog.SuccessId;
                case LogTypeEnum.WARNING:
                    return Configuration.EventLog.WarningId;
                case LogTypeEnum.ERROR:
                    return Configuration.EventLog.ErrorId;
                case LogTypeEnum.EXCEPTION:
                    return Configuration.EventLog.ExceptionId;
                case LogTypeEnum.TRACKING:
                    return Configuration.EventLog.TrackingId;
                case LogTypeEnum.PROCESS:
                    return Configuration.EventLog.ProcessId;
                case LogTypeEnum.INFO:
                    return Configuration.EventLog.InfoId;
                default:
                    return Configuration.EventLog.InfoId;
            }
        }

        private EventLogEntryType GetEntryType(LogTypeEnum pEnmType)
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
