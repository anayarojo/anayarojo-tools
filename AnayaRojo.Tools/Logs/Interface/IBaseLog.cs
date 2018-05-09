using AnayaRojo.Tools.Logs.Enums;

namespace AnayaRojo.Tools.Logs.Interface
{
    interface IBaseLog
    {
        void WriteLog(string pStrMessage);

        void WriteLog(LogTypeEnum pEnmType, string pStrMessage);

        void WriteLog(LogTypeEnum pEnmType, bool pBolIsSubLog, string pStrSubLogName, string pStrMessage);

        void WriteLog(LogTypeEnum pEnmType, string pStrFormat, params object[] pArrObjArgs);

        void WriteLog(LogTypeEnum pEnmType, bool pBolIsSubLog, string pStrSubLogName, string pStrFormat, params object[] pArrObjArgs);
    }
}
