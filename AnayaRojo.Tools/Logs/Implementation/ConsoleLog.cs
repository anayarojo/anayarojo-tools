using AnayaRojo.Tools.Logs.Enums;
using AnayaRojo.Tools.Logs.Interface;
using System;

namespace AnayaRojo.Tools.Logs.Implementation
{
    public class ConsoleLog : BaseLog, IBaseLog
    {
        public void WriteLog(string pStrMessage)
        {
            ConsoleWriteLine(pStrMessage, ConsoleColor.Gray);
        }

        public void WriteLog(LogTypeEnum pEnmType, string pStrMessage)
        {
            ConsoleWriteLine(pStrMessage, GetConsoleColor(pEnmType));
        }

        public void WriteLog(LogTypeEnum pEnmType, bool pBolIsSubLog, string pStrSubLogName, string pStrMessage)
        {
            ConsoleWriteLine(pBolIsSubLog ? string.Format("{0} ─ {1}", pStrMessage) : pStrMessage, GetConsoleColor(pEnmType));
        }

        public void WriteLog(LogTypeEnum pEnmType, string pStrFormat, params object[] pArrObjArgs)
        {
            ConsoleWriteLine(string.Format(pStrFormat, pArrObjArgs), GetConsoleColor(pEnmType));
        }

        public void WriteLog(LogTypeEnum pEnmType, bool pBolIsSubLog, string pStrSubLogName, string pStrFormat, params object[] pArrObjArgs)
        {
            ConsoleWriteLine(pBolIsSubLog ? string.Format("{0} ─ {1}", string.Format(pStrFormat, pArrObjArgs)) : string.Format(pStrFormat, pArrObjArgs), GetConsoleColor(pEnmType));
        }

        private ConsoleColor GetConsoleColor(LogTypeEnum pEnmType)
        {
            switch (pEnmType)
            {
                case LogTypeEnum.SUCCESS:
                    return ConsoleColor.Green;
                case LogTypeEnum.WARNING:
                    return ConsoleColor.DarkYellow;
                case LogTypeEnum.ERROR:
                    return ConsoleColor.Red;
                case LogTypeEnum.EXCEPTION:
                    return ConsoleColor.Red;
                case LogTypeEnum.TRACKING:
                    return ConsoleColor.Gray;
                case LogTypeEnum.PROCESS:
                    return ConsoleColor.Yellow;
                case LogTypeEnum.INFO:
                    return ConsoleColor.Gray;
                default:
                    return ConsoleColor.Gray;
            }
        }

        private void ConsoleWriteLine(string pStrMessage, ConsoleColor pEnmColor)
        {
            if (Configuration.ConsoleLog.Active)
            {
                Console.ForegroundColor = pEnmColor;
                Console.WriteLine(pStrMessage);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
