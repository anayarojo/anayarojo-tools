using AnayaRojo.Tools.Configs.Models;
using AnayaRojo.Tools.Extensions.Enums;
using AnayaRojo.Tools.Extensions.String;
using AnayaRojo.Tools.Logs.Enums;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;

namespace AnayaRojo.Tools.Logs
{
    /// <summary>
    ///     Herramienta para guardar logs en un archivo .log
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 27/05/2018
    /// </remarks>
    public class Log
    {
        private static LogsConfigurationModel mObjConfiguration;
        private static ReaderWriterLock mObjLocker = new ReaderWriterLock();

        /// <summary>
        ///     Obtener la configuración de los logs.
        /// </summary>
        public static LogsConfigurationModel Configuration
        {
            get
            {
                if (mObjConfiguration == null)
                {
                    mObjConfiguration = GetLogsConfiguration();
                }
                return mObjConfiguration;
            }
        }

        /// <summary>
        ///     Escribir log.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje.
        /// </param>
        public static void Write(string pStrMessage)
        {
            WriteLog(LogTypeEnum.INFO, pStrMessage);
        }

        /// <summary>
        ///     Escribir log.
        /// </summary>
        /// <param name="pEnmType">
        ///     Tipo de log.
        /// </param>
        /// <param name="pStrMessage">
        ///     Mensaje.
        /// </param>
        public static void Write(LogTypeEnum pEnmType, string pStrMessage)
        {
            WriteLog(pEnmType, pStrMessage);
        }
        
        /// <summary>
        ///     Escribir log.
        /// </summary>
        /// <param name="pEnmType">
        ///     Tipo de log.
        /// </param>
        /// <param name="pStrFormat">
        ///     Formato.
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parametros.
        /// </param>
        public static void Write(LogTypeEnum pEnmType, string pStrFormat, params object[] pArrObjArgs)
        {
            WriteLog(pEnmType, string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Escribir excepción log.
        /// </summary>
        /// <param name="pObjException">
        ///     Excepción.
        /// </param>
        public static void Write(Exception pObjException)
        {
            if (Configuration.Log.FullLog)
            {
                WriteLog(LogTypeEnum.EXCEPTION, pObjException.ToString());
            }
            else
            {
                WriteLog(LogTypeEnum.EXCEPTION, pObjException.Message);
            }
        }
        
        private static void WriteLog(LogTypeEnum pEnmType, string pStrMessage)
        {
            if(Configuration.Log.Active)
            {
                try
                {
                    mObjLocker.AcquireWriterLock(int.MaxValue);
                    File.AppendAllLines(GetLogPath(), GetFormattedMessage(pEnmType, pStrMessage));
                }
                catch
                {
                    File.AppendAllLines(GetAlternativeLogPath(), GetFormattedMessage(pEnmType, pStrMessage));
                }
                finally
                {
                    mObjLocker.ReleaseWriterLock();
                }
            }
        }

        private static string[] GetFormattedMessage(LogTypeEnum pEnmType, string pStrMessage)
        {
            string lStrFormat = !string.IsNullOrEmpty(Configuration.Log.Format) ? Configuration.Log.Format : "{date} [{type}] {message}";
            string lStrDateFormat = !string.IsNullOrEmpty(Configuration.Log.DateFormat) ? Configuration.Log.DateFormat : "yyyy-MM-dd HH:mm:ss";
            string lStrFormattedMessage = lStrFormat
                .InjectSingleValue("date", DateTime.Now.ToString(lStrDateFormat))
                .InjectSingleValue("type", pEnmType.GetDescription())
                .InjectSingleValue("message", pStrMessage);

            return new[] { lStrFormattedMessage };
        }

        private static string GetAlternativeLogPath()
        {
            return GetLogPath().Replace(".log", string.Format(" {0}.log", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")));
        }
        
        private static string GetLogPath()
        {
            string lStrAppPath = "";
            string lStrLogPath = "";
            string lStrDirPath = ""; 

            if (!string.IsNullOrEmpty(GetConfigPath()) && Directory.Exists(GetConfigPath()))
            {
                lStrAppPath = GetConfigPath();
            }
            else
            {
                lStrAppPath = GetAppPath();
            }
            
            if (Configuration.Log.MultiFiles)
            {
                lStrDirPath = Path.Combine(lStrAppPath, "Logs");
                lStrLogPath = Path.Combine(lStrDirPath, string.Format("{0}.log", DateTime.Now.ToString("yyyyMMdd")));

                if (!Directory.Exists(lStrDirPath))
                {
                    Directory.CreateDirectory(lStrDirPath);
                }
            }
            else
            {
                lStrAppPath = Path.Combine(lStrAppPath, GetLogName());
            }
            
            return lStrLogPath;
        }

        private static string GetLogName()
        {
            return string.Format("{0}.log", !string.IsNullOrEmpty(Configuration.Log.FileName) ? Configuration.Log.FileName : Assembly.GetExecutingAssembly().GetName().Name);
        }
        
        private static string GetConfigPath()
        {
            if (Configuration.Log.RelativePath)
            {
                return Path.Combine(GetAppPath(), Configuration.Log.Path);
            }
            else
            {
                return Configuration.Log.Path;
            }
        }

        private static string GetAppPath()
        {
            if (Configuration.Log.WebLog)
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
            }
            else
            {
                return System.Web.HttpContext.Current.Server.MapPath("/");
            }
        }
        
        private static LogsConfigurationModel GetLogsConfiguration()
        {
            return ConfigurationManager.GetSection("logsConfiguration") as LogsConfigurationModel;
        }
    }
}
