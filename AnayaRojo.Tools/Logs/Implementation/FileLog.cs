using AnayaRojo.Tools.Logs.Interface;
using System;

namespace AnayaRojo.Tools.Logs.Implementation
{
    public class FileLog : IBaseLog
    {
        public void WriteLog(string pStrMessage)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(Enums.LogTypeEnum pEnmType, string pStrMessage)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(Enums.LogTypeEnum pEnmType, bool pBolIsSubLog, string pStrSubLogName, string pStrMessage)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(Enums.LogTypeEnum pEnmType, string pStrFormat, params object[] pArrObjArgs)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(Enums.LogTypeEnum pEnmType, bool pBolIsSubLog, string pStrSubLogName, string pStrFormat, params object[] pArrObjArgs)
        {
            throw new NotImplementedException();
        }
    }
}
