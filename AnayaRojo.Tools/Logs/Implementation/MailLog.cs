using AnayaRojo.Tools.Logs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnayaRojo.Tools.Logs.Implementation
{
    public class MailLog : IBaseLog
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
