using AnayaRojo.Tools.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace AnayaRojo.Tools.Log
{
    /// <summary>
    ///     Librería para registrar registros en el log de la aplicación
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 14/12/2017
    /// </remarks>
    public static class ArLog
    {
        private static bool mBolShowConsole = false;
        private static bool mBolSaveEventLog = false;
        private static bool mBolFullLog = false;
        private static string mStrLogName = "log";

        static ArLog()
        {
            try
            {
                mBolShowConsole = ArConfig.GetValue<bool>("ShowConsole");
                mBolSaveEventLog = ArConfig.GetValue<bool>("SaveEventLog");
                mBolFullLog = ArConfig.GetValue<bool>("FullLog");
                mStrLogName = ArConfig.GetValue<string>("LogName");
            }
            catch
            {
                //Ignore exceptions
            }
        }

        /// <summary>
        ///     Propiedad que indica si se esta registrando un log detallado, esta propiedad se puede cambiar desde el App/Web.config
        /// </summary>
        public static bool FullLog
        {
            get { return mBolFullLog; }
        }

        /// <summary>
        ///     Propiedad que indica si se mostrara la consola por cada registro del log ingresado, esta propiedad se puede cambiar desde el App/Web.config
        /// </summary>
        public static bool ShowConsole
        {
            get { return mBolShowConsole; }
        }

        /// <summary>
        ///     Propiedad que indica si se guardara en el log de eventos, esta propiedad se puede cambiar desde el App/Web.config
        /// </summary>
        public static bool SaveEventLog
        {
            get { return mBolSaveEventLog; }
        }

        /// <summary>
        ///     Propiedad que indica el nombre del archivo del log, esta propiedad se puede cambiar desde el App/Web.config
        /// </summary>
        public static string LogName
        {
            get { return mStrLogName; }
        }

        /// <summary>
        ///     Método para registrar un texto libre directamente en el log.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void Write(string pStrLogName, string pStrFormat, params object[] pArrObjArgs)
        {
            Write(pStrLogName, string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar un texto libre directamente en el log.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void Write(string pStrLogName, string pStrMessage)
        {
            string lStrApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
            string lStrDirPath = Path.Combine(lStrApplicationPath, "Logs");
            string lStrDateDirPath = Path.Combine(lStrDirPath, DateTime.Now.ToString("yyyyMMdd"));
            string lStrLogPath = Path.Combine
            (
                lStrDateDirPath,
                string.Format("{0}.log", !string.IsNullOrEmpty(pStrLogName) ? pStrLogName : ArLog.LogName)
            );
            string lStrDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ");

            try
            {
                if (!Directory.Exists(lStrDirPath))
                {
                    Directory.CreateDirectory(lStrDirPath);
                }

                if (!Directory.Exists(lStrDateDirPath))
                {
                    Directory.CreateDirectory(lStrDateDirPath);
                }

                using (StreamWriter lObjWriter = new StreamWriter(lStrLogPath, true))
                {
                    lObjWriter.WriteLine(string.Concat(lStrDate, pStrMessage));
                }
            }
            catch
            {
                lStrLogPath = Path.Combine
                (
                    lStrDateDirPath,
                    string.Format
                    (
                        "{0} {1}.log",
                        !string.IsNullOrEmpty(pStrLogName) ? pStrLogName : ArLog.LogName,
                        DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")
                    )
                );
                using (StreamWriter lObjWriter = new StreamWriter(lStrLogPath, true))
                {
                    lObjWriter.WriteLine(string.Concat(lStrDate, pStrMessage));
                }
            }
        }

        /// <summary>
        ///     Método para registrar un texto libre directamente en el log.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void Write(string pStrMessage)
        {
            Write("", pStrMessage);
        }

        /// <summary>
        ///     Método para registrar información en el log.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteInfo(string pStrMessage)
        {
            Write("", "[INFO] {0}", pStrMessage);
            WriteEventLog(pStrMessage, EventLogEntryType.Information, 40);
            ConsoleWriteLine(pStrMessage, ConsoleColor.Gray);
        }

        /// <summary>
        ///     Método para registrar información en el log.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteInfo(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteInfo(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar información en el log.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteInfo(string pStrLogName, string pStrMessage)
        {
            Write(pStrLogName, "[INFO] {0}", pStrMessage);
            WriteEventLog(pStrMessage, EventLogEntryType.Information, 41);
            ConsoleWriteLine(pStrMessage, ConsoleColor.Gray);
        }

        /// <summary>
        ///     Método para registrar información en el log.
        /// </summary>
        /// <param name="pstrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteInfo(string pstrLogName, string pStrFormat, params object[] pArrObjArgs)
        {
            WriteInfo(pstrLogName, string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar un evento exitoso, tal evento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteSuccess(string pStrMessage)
        {
            if (FullLog)
            {
                Write("", "[SUCCESS] {0}", pStrMessage);
                WriteEventLog(pStrMessage, EventLogEntryType.Information, 30);
                ConsoleWriteLine(pStrMessage, ConsoleColor.Green);
            }
        }

        /// <summary>
        ///     Método para registrar un evento exitoso, tal evento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteSuccess(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteSuccess(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar un evento exitoso, tal evento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteSuccess(string pStrLogName, string pStrMessage)
        {
            if (FullLog)
            {
                Write(pStrLogName, "[SUCCESS] {0}", pStrMessage);
                WriteEventLog(pStrMessage, EventLogEntryType.Information, 33);
                ConsoleWriteLine(pStrMessage, ConsoleColor.Green);
            }
        }

        /// <summary>
        ///     Método para registrar un evento exitoso, tal evento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteSuccess(string pStrLogName, string pStrFormat, params object[] pArrObjArgs)
        {
            WriteSuccess(pStrLogName, string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar el seguimiento de un evento, tal seguimiento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteTracking(string pStrMessage)
        {
            if (FullLog)
            {
                Write("", "[TRACK] {0}", pStrMessage);
                WriteEventLog(pStrMessage, EventLogEntryType.Information, 10);
                ConsoleWriteLine(pStrMessage, ConsoleColor.Gray);
            }
        }

        /// <summary>
        ///     Método para registrar el seguimiento de un evento, tal seguimiento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteTracking(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteTracking(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar el seguimiento de un evento, tal seguimiento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteTracking(string pStrLogName, string pStrMessage)
        {
            if (FullLog)
            {
                Write(pStrLogName, "[TRACK] {0}", pStrMessage);
                WriteEventLog(pStrMessage, EventLogEntryType.Information, 11);
                ConsoleWriteLine(pStrMessage, ConsoleColor.Gray);
            }
        }

        /// <summary>
        ///     Método para registrar el seguimiento de un evento, tal seguimiento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteTracking(string pStrLogName, string pStrFormat, params object[] pArrObjArgs)
        {
            WriteTracking(pStrLogName, string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar el evento de un proceso, tal evento solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteProcess(string pStrMessage)
        {
            if (FullLog)
            {
                Write("", "[PROCESS] {0}", pStrMessage);
                WriteEventLog(pStrMessage, EventLogEntryType.Information, 20);
                ConsoleWriteLine(pStrMessage, ConsoleColor.Yellow);
            }
        }

        /// <summary>
        ///     Método para registrar el evento de un proceso, tal evento solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteProcess(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteProcess(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar el evento de un proceso, tal evento solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteProcess(string pStrLogName, string pStrMessage)
        {
            if (FullLog)
            {
                Write(pStrLogName, "[PROCESS] {0}", pStrMessage);
                WriteEventLog(pStrMessage, EventLogEntryType.Information, 21);
                ConsoleWriteLine(pStrMessage, ConsoleColor.Yellow);
            }
        }

        /// <summary>
        ///     Método para registrar el evento de un proceso, tal evento solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteProcess(string pStrLogName, string pStrFormat, params object[] pArrObjArgs)
        {
            WriteProcess(pStrLogName, string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar una advertencia, tal advertencia solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteWarning(string pStrMessage)
        {
            if (FullLog)
            {
                Write("", string.Format("[WARNING] {0}", pStrMessage));
                WriteEventLog(pStrMessage, EventLogEntryType.Warning, 50);
                ConsoleWriteLine(pStrMessage, ConsoleColor.DarkYellow);
            }
        }

        /// <summary>
        ///     Método para registrar una advertencia, tal advertencia solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteWarning(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteWarning(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar una advertencia, tal advertencia solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteWarning(string pStrLogName, string pStrMessage)
        {
            if (FullLog)
            {
                Write(pStrLogName, string.Format("[WARNING] {0}", pStrMessage));
                WriteEventLog(pStrMessage, EventLogEntryType.Warning, 51);
                ConsoleWriteLine(pStrMessage, ConsoleColor.DarkYellow);
            }
        }

        /// <summary>
        ///     Método para registrar una advertencia, tal advertencia solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteWarning(string pStrLogName, string pStrFormat, params object[] pArrObjArgs)
        {
            WriteWarning(pStrLogName, string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar un error.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteError(string pStrMessage)
        {
            Write("", "[ERROR] {0}", pStrMessage);
            WriteEventLog(pStrMessage, EventLogEntryType.Error, 60);
            ConsoleWriteLine(pStrMessage, ConsoleColor.Red);
        }

        /// <summary>
        ///     Método para registrar un error.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteError(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteError(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar un error.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteError(string pStrLogName, string pStrMessage)
        {
            Write(pStrLogName, "[ERROR] {0}", pStrMessage);
            WriteEventLog(pStrMessage, EventLogEntryType.Error, 61);
            ConsoleWriteLine(pStrMessage, ConsoleColor.Red);
        }

        /// <summary>
        ///     Método para registrar un error.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteError(string pStrLogName, string pStrFormat, params object[] pArrObjArgs)
        {
            WriteError(pStrLogName, string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar una excepción.
        /// </summary>
        /// <param name="pObjException">
        ///     Excepción
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteException(Exception pObjException)
        {
            if (pObjException != null)
            {
                if (FullLog)
                {
                    Write("", "[ERROR] {0}", pObjException.ToString());
                }
                else
                {
                    Write("", "[ERROR] {0}", pObjException.Message);
                }
                WriteEventLog(pObjException.ToString(), EventLogEntryType.Error, 70);
                ConsoleWriteLine(pObjException.ToString(), ConsoleColor.Red);
            }
        }

        /// <summary>
        ///     Método para registrar una excepción.
        /// </summary>
        /// <param name="pStrLogName">
        ///     Nombre del log
        /// </param>
        /// <param name="pObjException">
        ///     Excepción
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteException(string pStrLogName, Exception pObjException)
        {
            if (pObjException != null)
            {
                if (FullLog)
                {
                    Write(pStrLogName, "[ERROR] {0}", pObjException.ToString());
                }
                else
                {
                    Write(pStrLogName, "[ERROR] {0}", pObjException.Message);
                }
                WriteEventLog(pObjException.ToString(), EventLogEntryType.Error, 71);
                ConsoleWriteLine(pObjException.ToString(), ConsoleColor.Red);
            }
        }

        private static void WriteEventLog(string pStrMessage, EventLogEntryType pEnmType, int pIntId)
        {
            if (SaveEventLog)
            {
                try
                {
                    EventLog lObjEventLog = new EventLog();
                    string lStrCurrentProcessName = Process.GetCurrentProcess().ProcessName;

                    if (!EventLog.SourceExists(lStrCurrentProcessName))
                    {
                        EventLog.CreateEventSource(lStrCurrentProcessName, "Application");
                    }

                    lObjEventLog.Source = lStrCurrentProcessName;
                    lObjEventLog.WriteEntry(pStrMessage, pEnmType, pIntId);
                    lObjEventLog.Close();
                }
                catch (Exception lObjException)
                {
                    if (FullLog)
                    {
                        Write("", "[ERROR] {0}", lObjException.ToString());
                    }
                    else
                    {
                        Write("", "[ERROR] {0}", lObjException.Message);
                    }
                }
            }
        }

        private static void ConsoleWriteLine(string pStrFormat, ConsoleColor pEnmColor, object pObjArg)
        {
            ConsoleWriteLine(string.Format(pStrFormat, pObjArg), pEnmColor);
        }

        private static void ConsoleWriteLine(string pStrFormat, ConsoleColor pEnmColor, params object[] pArrObjArgs)
        {
            ConsoleWriteLine(string.Format(pStrFormat, pArrObjArgs), pEnmColor);
        }

        private static void ConsoleWriteLine(string pStrMessage, ConsoleColor pEnmColor)
        {
            if (ShowConsole)
            {
                Console.ForegroundColor = pEnmColor;
                Console.WriteLine(pStrMessage);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
