﻿using AnayaRojo.Tools.Logs.Enums;
using System;

namespace AnayaRojo.Tools.Logs
{
    /// <summary>
    ///     Herramienta para mostrar los logs en la consola.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 27/05/2018
    /// </remarks>
    public class ConsoleLog
    {
        /// <summary>
        ///     Mostrar log.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje.
        /// </param>
        public void Show(string pStrMessage)
        {
            ConsoleWrite(pStrMessage, ConsoleColor.Gray);
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
        public void Show(LogTypeEnum pEnmType, string pStrMessage)
        {
            ConsoleWrite(pStrMessage, GetConsoleColor(pEnmType));
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
        public void Show(LogTypeEnum pEnmType, string pStrFormat, params object[] pArrObjArgs)
        {
            ConsoleWrite(string.Format(pStrFormat, pArrObjArgs), GetConsoleColor(pEnmType));
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

        private void ConsoleWrite(string pStrMessage, ConsoleColor pEnmColor)
        {
            if (Log.Configuration.ConsoleLog.Active)
            {
                Console.ForegroundColor = pEnmColor;
                Console.WriteLine(pStrMessage);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}